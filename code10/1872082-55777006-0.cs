    class Foo : MonoBehaviour 
    {
        [SerializableField]
        private bool shooting = false;
        [SerializableField]
        private Animator anim;
    
        public void Update() 
        {
            if (shooting)
            {
                //if the shooting variable is set to true on the if below, it will start shooting
                anim.Play("Shooting");
                LaunchProjectile();
            }
            
            if (!shooting && Input.GetButtonDown("Fire1"))
            {
                anim.Play("Shooting");
                LaunchProjectile();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                //reversing the shooting variable
                shooting = !shooting;
                if (shooting)
                {
                    //this is just to make sure it will shoot right away
                    //and not on the next frame
                    anim.Play("Shooting");
                    LaunchProjectile();
                }
            }
        }
    }
