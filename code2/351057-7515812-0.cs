    DateTime lastDT = DateTime.MinValue;
    private void TimerTick(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        if (now - last).TotalSeconds > what_you_want
        {
            //My functionality
        }
        last = now;
    }
