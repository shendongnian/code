    public class StarGenSo : MonoBehaviour
    {
        [Header("Galaxy")]
        public int numberOfStars = 300;
        public int maximumRadius = 100;
        public float minDistBetweenStars = 2f;
        [Header("Star")]
        public float minimumSize = 1f;
        public float maximumSize = 2f;
    
        IEnumerator Start()
        {
            for (int i = 0; i < numberOfStars; i++)
            {
                float distance = Random.Range(0, maximumRadius);
                float angle = Random.Range(0, 2 * Mathf.PI);
    
                float starSize = Random.Range(minimumSize, maximumSize);
                Vector3 starPosition = new Vector3(distance * Mathf.Cos(angle), 0, distance * Mathf.Sin(angle));
    
                Collider[] starCollider = Physics.OverlapSphere(starPosition, (starSize * 0.5f) + minDistBetweenStars);
                if (starCollider.Length == 0)
                {
                    GameObject star = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    star.transform.position = starPosition;
                    star.transform.localScale = new Vector3(starSize, starSize, starSize);
                }
                else
                {
                    i--;
                }
                yield return null;
            }
            yield return null;
        }
    }
