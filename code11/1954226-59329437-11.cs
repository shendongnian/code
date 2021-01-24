        void pressSpacebar()
        {
            if (Input.GetKeyDown("space"))
            {
                if (!timerIsRunning)
                {
                    timerIsRunning = true;
                    print("Timer Running");
                    //to check if bool changed (and not just the text)
                    print(timerIsRunning);
                    break;
                }
                //REMOVED ELSE CLAUSE
                timerIsRunning = false;
                print("Timer Stopped");
                print(timerIsRunning);
            }
        }
    
        bool timerIsRunning;
    }
