    public class ShootScript : MonoBehaviour
    {
        // Hint: By making the prefab field Rigidbody you later can skip GetComponent
        public Rigidbody bulletPrefab;
        public float shootSpeed = 300;
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                shootBullet();
            }
        }
    
        void shootBullet()
        {
            Rigidbody projectile = Instantiate (bulletPrefab, transform.position, transform.rotation);
    
            //Shoot the Bullet
            projectile.velocity = transform.forward * shootSpeed;
        }
    }
