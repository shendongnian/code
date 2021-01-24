    void pressSpacebar()
    {
        if (Input.GetKeyDown("space"))
        {
            TimerManager();
        }
    }
    
    void TimerManager()
    {
        //Source: @Enigmativity
        //Sets by using the not operator. Acts as a switch.
        timerIsRunning = !timerIsRunning;
    }
