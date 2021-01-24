    using UnityEngine;
    
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] AudioSource dropSound = null;
        protected Rigidbody body = null;
        protected int bullets = 10;
        protected float reloadSeconds = 0.5f;
    
        protected virtual void Fire()
        {
            if (bullets > 0)
            {
                bullets--;
                FireBullet();
            }
        }
        
        // etc.
    }
