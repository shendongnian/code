    void pressSpacebar()
        {
            if (Input.GetKeyDown("space"))
            {
                if (!timerIsRunning)
                {
                    StartTimer();
                }
                //REMOVED ELSE CLAUSE
                    StopTimer();
            }
        }
    
        bool timerIsRunning;
    
        void StartTimer()
        {
            timerIsRunning = true;
            print("Timer Running");
            //to check if bool changed (and not just the text)
            print(timerIsRunning);
        }
    
        void StopTimer()
        {
            timerIsRunning = false;
            print("Timer Stopped");
            print(timerIsRunning);
    
        }
    
