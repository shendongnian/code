    private float playerSpeed = 5.2f;
    private float slideDuration = 2.0f;
    private float remainingSlideTime = 2.0f;
    
    void update() {  
        isSliding = (Input.GetKey(KeyCode.Space) && (isRunning == true || isSprinting == 1));
    
        if(isSliding && remainingSlideTime < slideDuration && playerSpeed > 0) {
			remainingSlideTime -= Time.deltaTime;
			float speedReduction = playerSpeed * (Time.deltaTime/remainingSlideTime);
			playerSpeed = Mathf.Lerp(playerSpeed - speedReduction, 0, remainingSlideTime/slideDuration);
        }
    }
