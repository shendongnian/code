    private int ticks = 0;
    
    private void timerTick(...)
    {
        if (2880 == ticks)
        {
            one_void();
            ticks = 0;
        }
    
        send_email();
    
        ticks++;
    }
