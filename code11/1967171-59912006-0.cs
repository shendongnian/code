    public class Test : MonoBehaviour {
        public bool isRotating;
        private bool observer;
        void Awake() {
            observer = isRotating;    
        }
        void Update() {
            if (isRotating) {
                transform.Rotate(0, 0, 100 * Time.deltaTime);
            }
            else if (isRotating != observer) {
                transform.eulerAngles = Vector3.zero;
            }
            observer = isRotating;
        }
    
    }
