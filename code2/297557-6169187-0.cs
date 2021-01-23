    private bool timer2Started;
    private void timer1_Tick(object sender, EventArgs e)
    {
        Console.WriteLine("Timer1 :" + DateTime.Now.ToString());
        if (!timer2Started) { timer2.Start(); timer2Started = true; }
    }
