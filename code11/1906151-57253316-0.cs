    private float timeToDoStuff = 0.0f;
    private float slidingDecrease = 0.0f;
    void update() {  
        if (Input.GetKey(KeyCode.Space) && (isRunning == true || isSprinting == 1))
        {
            if(!isSliding) slidingDecrease = playerSpeed / 2;
            isSliding = true;         
        }      
        else
        {
            slidingDecrease = 0.0f;
            isSliding = false;
        }
        if(isSliding && Time.time >= timeToDoStuff) {
            playerSpeed -= slidingDecrease; // or whatever
            timeToDoStuff = Time.time + 1.0f; // for 1 seconds
        }
    }
