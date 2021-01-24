    bool timerIsRunning;
    void Update() // I'm leaving this unchanged as you might need to add more context here, otherwise, feel free to unline `pressSpacebar()` here and remove more lines
    {
        pressSpacebar();
    }
    void pressSpacebar() {
       if (Input.GetKeyDown("space")) 
           print($"Timer {((timerIsRunning ^= true) ? "Running" : "Stopped")}, {timerIsRunning}");
    }
