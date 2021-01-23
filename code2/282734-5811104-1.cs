    void TimerTick(object state)
    {
        int timerNumber = (int)state;
        list[timerNumber].Change(Timeout.Infinite, Timeout.Infinite); // stops the timer.
    }
