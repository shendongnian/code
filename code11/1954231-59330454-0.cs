    bool timerIsRunning;
    void pressSpacebar() { 
       if (Input.GetKeyDown("space")) 
           print($"Timer {(timerIsRunning ^= true)? "Running":"Stopped"}, {timerIsRunning}");
    }
