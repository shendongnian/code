    public DateTime LastMaxDateTime;
    
    protected void Application_Start(object sender,EventArgs e)
    {
        LastMaxDateTime = GetMaxDateTime();
    
        Thread bgThread=new Thread(BackgroundThread_CheckDatabase);
        bgThread.IsBackground=true;
        bgThread.Start();
    }
    
    private void BackgroundThread_CheckDatabase()
    {
        while(true)
        {
            DateTime dtMaxDateTime = GetMaxDateTime();
            if(dtMaxDateTime > this.LastMaxDateTime)
            {
                //Send Notifications
                this.LastMaxDateTime=dtMaxDateTime;
            }
    
            Thread.Sleep(5000); //5 seconds
        }
    }
    
    private DateTime GetMaxDateTime()
    {
         //function that returns DateTime from something like "SELECT MAX(DateTimeColumn) FROM [MyTable]"
    }
