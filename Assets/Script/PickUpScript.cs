using TMPro;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    [SerializeField] GameObject targetItem;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float Maxdistance;
    [SerializeField] TextMeshProUGUI UIText;
    [SerializeField] bool isHolding = false;
    private void Update()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, Maxdistance, layerMask))
        {
            targetItem = hit.collider.gameObject;
            if (!isHolding) UIText.text = "Pick Up";
        }
        else
        {
            targetItem = null;
            UIText.text = " ";
        }

        if(isHolding) UIText.text = "Drop";

        if (Input.GetKeyDown(KeyCode.E) && targetItem != null)
        {
            isHolding = !isHolding;
            if (isHolding)
            {
                
                targetItem.transform.SetParent(transform);
                targetItem.GetComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                
                targetItem.transform.SetParent(null);
                targetItem.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

}
