    public class Target : MonoBehaviour
    {
        public float health = 50f;
        private static float totalCubesHit = 0;
        // Optionally add a public ReadOnly property 
        // for allowing external access
        public static float TotalCubesHit => totalCubesHit;
        public void TakeDamage (float amount)
        {
            health -= amount;
            if (health <= 0f) 
            {
                totalCubesHit++;
                Die(); 
            }
        }
        public void Die()
        {
            Destroy(gameObject);
            Debug.Log(totalCubesHit);
        }
    }
