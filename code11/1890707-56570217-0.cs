    public class ExampleClass : MonoBehaviour
    {
        public Transform target;
    
        void Update()
        {
            // Rotate the OBJECT every frame so it keeps looking at the target
            transform.LookAt(target);
        }
    }
    
