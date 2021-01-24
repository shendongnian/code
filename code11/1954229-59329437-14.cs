        void pressSpacebar()
        {
            if (Input.GetKeyDown("space"))
            {
               //Source: @Enigmativity
               //Sets by using the not operator. Acts as a switch.
               timerIsRunning = !timerIsRunning;
               print(timerIsRunning);
            }
        }
