    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField]
        public PlayerInput Input;
        private void Awake()
        {
            Input = new PlayerInput(); <<<<<<<<<<<
            Input.Enable();        
        }
        ...
    }
