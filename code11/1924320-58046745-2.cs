    public class DamageDealer : MonoBehaviour
    {
        // if possible already reference this via the Inspector
        [SerializeField] private Rigidbody2D rigidbody;
        // This is a read-only property returning the value of rigidbody
        public Rigidbody2D Rigidbody => rigidbody;
        private void Awake()
        {
            if(!rigidbody) rigidbody = GetComponnet<Rigidbody2D>();
            ...
        }
        ...
    }
