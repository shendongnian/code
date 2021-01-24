    public class PlayerControlls : MonoBehaviour
    {
        public static PlayerControlls Instance;
        private Rigidbody ThisBody = null;
        private static Quaternion e_rotation = new Quaternion(0, 0, 0, 0);
        public Transform ThisTransform = null;
        public static float m_ZAxis;
        public static float m_WAxis;
    
        void Awake()
        {
            Instance = this;
            ThisBody      = GetComponent<Rigidbody>();
            ThisTransform = GetComponent<Transform>();
        }
    
        public void Rotation(float m_ZAxis, float m_WAxis)
        {
    
            e_rotation.z       = m_ZAxis;
            e_rotation.w       = m_WAxis;
            transform.rotation = e_rotation;
        }
    }
