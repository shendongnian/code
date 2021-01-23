    public void Update(double x, double y)
    {   
        try
        { 
           //...long running task... 
        }
        finally
        { 
           Interlocked.CompareExchange(ref lockCookie, 0, 1);  //Reset to 0, if it is 1
        }
    }
    //....
    void Provider_PositionChanged(object sender, SpecialEventArgs e)
    {
        if (Interlocked.CompareExchange(ref lockCookie, 1, 0) == 0) //Set to 1, if it is 0
        {
            myUiControl.BeginInvoke(/*...*/);
        }       
    }
