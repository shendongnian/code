    StartCoroutine(PowerUpRoutine());
    ...    
    private IEnumerator PowerUpRoutine()
    {
        isDoublePoints = true;
        
        while(powerUpTimer > 0)
        {
            // Countdown the timer with update time
            powerUpTimer -= Time.deltaTime;
            //Debug.Log("TIMER ISS " + powerUpTimer);
            
            // yield in simple words makes Unity "pause"
            // the execution here, render this frame and continue from here
            // in the next frame
            yield return null;
        }
            
        // End of power up time 
        isDoublePoints = false;
    }
    public void OnPickPowerUp(float buffTime)
    {
        powerUpTimer += buffTime;
        // avoid concurrent routines
        if(!isDoublePoints) StartCoroutine(PowerUpRoutine());
    }
