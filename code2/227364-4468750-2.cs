    private void Form_Load()
    {
        timer1.Interval = 1000; // 1 second
        timer1.Start(); // This will raise Tick event after 1 second
        OnTick(); // So, call Tick event explicitly when we start timer
    }
    Int32 counter = 0;
    private void timer1_Tick(object sender, EventArgs e)
    {
        OnTick();
    }
    private void OnTick()
    {
        if (counter % 1 == 0)
        {
            OnOneSecond();
        }
        if (counter % 2 == 0)
        {
            OnTwoSecond();
        }
        counter++;
    }
