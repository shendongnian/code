    void pressSpacebar()
    {
        if (Input.GetKeyDown("space"))
        {
            TimerManager();
        }
    }
    
    void TimerManager()
    {
        if(timerIsRunning) { timerIsRunning = false; }
        else { timerIsRunning = true; }
    }
