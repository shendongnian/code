        //put your shooting scripts name below.
        private ShootScript shootScript = shootScript; 
        
        void start()
        {    
        
        shootScript = GetComponent<ShootScript>();
        
        }
        void Movement()
            {
                shootScript.isMoving = true; 
    
    transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * WalkSpeed * Time.deltaTime);
                transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * WalkSpeed * Time.deltaTime);
            
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    WalkSpeed = RunSpeed;
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    WalkSpeed = DefaultSpeed;
                }
            }`
