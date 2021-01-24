    public class StarGenSO : MonoBehaviour
    {
        [Header("Galaxy")]
        public int numberOfStars = 300;
        public int maximumRadius = 100;
        public float minDistBetweenStars = 2f;
        [Header("Star")]
        public float minimumSize = 1f;
        public float maximumSize = 2f;
    
        void Awake()
        {
            for (int i = 0; i < numberOfStars; i++)
            {
                GameObject star = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    
                float distance = Random.Range(0, maximumRadius);
                float angle = Random.Range(0, 2 * Mathf.PI);
    
                float starSize = Random.Range(minimumSize, maximumSize);
                Vector3 starPosition = new Vector3(distance * Mathf.Cos(angle), 0, distance * Mathf.Sin(angle));
    
                var currentCol = star.GetComponent<Collider>();
                currentCol.enabled = false;
    
                Collider[] starCollider = Physics.OverlapSphere(starPosition, (starSize * 0.5f) + minDistBetweenStars);
                if (starCollider.Length == 0)
                {
                    star.transform.position = starPosition;
                    star.transform.localScale = new Vector3(starSize, starSize, starSize);
                    currentCol.enabled = true;
                }
                else
                {
                    Debug.Log("remove");
                    Destroy(star);
                    i--;
                }
            }
        }
    }
