    public class ResetPosition : MonoBehaviour
    {
        public Vector3 resetPosition;
        private void Awake()
        {
            // create a new object and make it parent of this object
            var parent = new GameObject("CameraParent").transform;
            transform.SetParent(parent);
        }
    
        // You should use LateUpdate
        // because afaik the oculus position is updated in the normal
        // Update so you are sure it is already done for this frame
        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("pressed");
    
                // reset parent objects position
                transform.parent.position = resetPosition - transform.position;
            }
        }
    }
