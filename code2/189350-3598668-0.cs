    private void Timer_Tick(object sender, EventArgs e)
    {
        new Thread(MethodThatDoesTheWork).Start();
    }
    
    private void MethodThatDoesTheWork()
    {
        // actual work goes here
    }
