    public class Spawning_Projectiles : MonoBehaviour
    {
        public GameObject projectile;
        GameObject Clone;
        bool hasCloned;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !hasCloned)
            {
                Clone = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
                hasCloned = true;
            }
        }
    
    }
