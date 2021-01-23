    public static class Job 
    { 
        public static string UpdatedValue { get; private set; } // Or whatever the property is you wish to expose.
        // The Execute method is called by a scheduler and must therefore  
        // have this exact signature (i.e. it cannot take any paramters). 
        public static string Execute() 
        { 
            // Do work
            Job.UpdatedValue = "Execute Completed";
        } 
    } 
    protected override OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.TextLabel.Text = Job.UpdatedValue;
    }
   
    // Using MSDN basic sample
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        this.TextLabel.Text = Job.UpdatedValue;
    }
