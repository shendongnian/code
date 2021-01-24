    public class ResetPosition : MonoBehaviour
    {
        private void Awake()
        {
           // create a new object and make it parent of this object
           var parent = new GameObject("CameraParent");
           parent.transform.position = transform.position;
           transform.SetParent(parent);
        }
    
        // Update is called once per frame
        private void Update()
        {
            // copy camera position to the parent object
            transform.parent.position = transform.position;
    
            // reset own/camera position
            transform.localPosition = new Vector3.zero;
    
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("pressed");
    
                // reset parent objects position
                transform.parent.position = new Vector3.zero;
            }
        }
    }
