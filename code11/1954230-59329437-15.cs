    void pressSpacebar()
    {
        if (Input.GetKeyDown("space"))
        {
            TimerManager();
        }
    }
    
    //INFO: Replaced startTimer() & stopTimer() with this to switch.
    void TimerManager()
    {
        //Source: @Enigmativity
        //Sets by using the not operator. Acts as a switch.
        timerIsRunning = !timerIsRunning;
        print(timerIsRunning);
    }
    
     
