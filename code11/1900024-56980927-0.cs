    float powerUpTimer;
    bool isDoublePoints = false;
    void Update()
    {
        // Check timer only when Power up time
        if(isDoublePoints)
        {
            // Countdown the timer with update time
            powerUpTimer -= Time.deltaTime;
            if(powerUpTimer <= 0)
            {
                // End of power up time 
                isDoublePoints = false;
            }
        }
    }
    // Add any time player picks to timer
    public void OnPickPowerUp(float buffTime)
    {
        powerUpTimer += buffTime;
    }
