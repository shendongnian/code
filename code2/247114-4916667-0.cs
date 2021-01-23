    protected void Application_Error( object sender, EventArgs e )
    {
        Exception Exc = null;
        try
        {
            Exc = Server.GetLastError();
            if(Exc.InnerException != null)
                Exc = Exc.InnerException;
            // Method name + line number + column
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(Exc, true);
            string ExtraData = "Name : {0}, Line : {1}, Column : {2}";
            ExtraData = String.Format(ExtraData, trace.GetFrame(0).GetMethod().Name, trace.GetFrame(0).GetFileLineNumber(), trace.GetFrame(0).GetFileColumnNumber());
            // exception message
            Exc.Message;
            // page name
            Request.Url.ToString();
            // stack trace
            Exc.StackTrace; 
        }
    }
