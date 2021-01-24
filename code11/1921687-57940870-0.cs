    public class sphereBehavior : MonoBehaviour
    {
        public GameObject object3;
        private Vector3 direction = new Vector3(-1, 0, 0);
        private Vector3 rotateDirection = new Vector3(0, 0, 1);
        private GameObject theCylinder;
    
        // Update is called once per frame
        void Update()
        {
            transform.Translate(direction * Time.deltaTime, Space.World);
            transform.Rotate(rotateDirection, Space.World);
    
            Quaternion newRotation = Quaternion.Euler(90,50,69);
            theCylinder.transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime); //reference it
        }
    
        void OnCollisionEnter(Collision collision)
        {
            theCylinder = Instantiate(object3, new Vector3(0, 1, -2), Quaternion.identity); //save a reference
            Destroy(collision.gameObject);
        }
    }
