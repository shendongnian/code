    public class PlayerInput : MonoBehaviour
    {
        private static bool _transmitInput;
        void Update()
        {
            if(!_transmitInput || EventSystem.current.IsPointerOverGameObject()) return;
            if (Input.GetMouseButtonDown(0))
            {
            //hide UI elements
            }
        }
        public static void DisableInput()
        {
            if (!_transmitInput) return;
            _transmitInput = false;
        }
        public static void EnableInput()
        {
            if (_transmitInput) return;
            _transmitInput = true;
        }
    }
