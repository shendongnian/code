    protected void Session_Start(Object Sender, EventArgs e)
    {
        // set the correct culture, using cookie, querystring, whatever
        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(1033);            
    }
