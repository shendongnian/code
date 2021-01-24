    public class VRPositionChange : MonoBehaviour
    {
        public Transform resetPos;
        private Transform parent;
        private void Awake()
        {
            // create a new object and make it parent of this object
            parent = gameObject.GetComponentInParent<Transform>();
        }
        // Update is called once per frame
        private void Update()
        {
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
            
                // reset parent objects position
               parent.position = resetPos.position;
            }
        }
    }
