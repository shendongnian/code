    public class Enemy: MonoBehaviour
    {
        public float speed = 10.0f;
        // You could reference this already in the Inspector
        [SerializeField] private Rigidbody2D rb;
        private Vector2 screenBounds;
    
        private void Awake()
        {
            if(!rb) rb = GetComponent<Rigidbody2D>();
            Scorescript.OnScoreChanged -= HandleScoreChange;
            Scorescript.OnScoreChanged += HandleScoreChange;
        }
        private void OnDestroy()
        {
            Scorescript.OnScoreChanged -= HandleScoreChange;
        }
        private void HandleScoreChange(int score)
        {
            rb.velocity = new Vector2(-speed * (score >= 10 ? 2 : 1), 0);
        }
    }
