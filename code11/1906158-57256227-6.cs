    private float playerSpeed = 5.2f;
    private float slideDuration = 2.0f;
    private float remainingSlideTime = 2.0f;
    
    void update() {  
        bool isSliding = (Input.GetKey(KeyCode.Space) && (isRunning == true || isSprinting == 1));
        if(isSliding && remainingSlideTime > 0 && playerSpeed > 0) {
			remainingSlideTime -= Time.deltaTime;
			float speedReduction = playerSpeed * (Time.deltaTime/remainingSlideTime);
			playerSpeed = ((remainingSlideTime/slideDuration) > 0) ? playerSpeed - speedReduction : 0;
        }
    }
