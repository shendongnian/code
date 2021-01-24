using UnityEngine;
using System.Collections;
 
public class DragAndDrop : MonoBehaviour
{  
    private bool _mouseState;
    private GameObject target;
    public Vector3 screenSpace;
    public Vector3 offset;
 
    // Use this for initialization
    void Start ()
    {
   
    }
   
    // Update is called once per frame
    void Update ()
    {
        // Debug.Log(_mouseState);
        if (Input.GetMouseButtonDown (0)) {
 
            RaycastHit hitInfo;
            target = GetClickedObject (out hitInfo);
            if (target != null) {
                _mouseState = true;
                screenSpace = Camera.main.WorldToScreenPoint (target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }
        }
        if (Input.GetMouseButtonUp (0)) {
            _mouseState = false;
        }
        if (_mouseState) {
            //keep track of the mouse position
            var curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
 
            //convert the screen mouse position to world point and adjust with offset
            var curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;
 
            //update the position of the object in the world
            target.transform.position = curPosition;
        }
    }
   
   
    GameObject GetClickedObject (out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray.origin, ray.direction * 10, out hit)) {
            target = hit.collider.gameObject;
        }
 
        return target;
    }
}
