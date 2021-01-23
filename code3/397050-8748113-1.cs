    void OnErrorCallback(Exception ex)
    {
       if(InvokeRequired)
       {
          //bring method execution up to the UI thread
          this.Invoke((MethodInvoker)(()=>OnErrorCallback(ex)));
          return;
       }
    
       //handle the exception, with access to UI components.
    }
    
    void GenerateReports() {
        foreach (var employee in employees) {
            GenerateReportAsync(employee, OnDoneCallback); // returns immediately
        }
    }
    
    void GenerateReportAsync(Employee employee, AsyncCallback OnDoneCallback)
    {
        //Delegate.BeginInvoke takes all parameters of the delegate, plus 
        //something to call when done, PLUS a state object that can be 
        //used to monitor work in progress (null is fine too).
        GenerateReport.BeginInvoke(employee, OnErrorCallback, OnDoneCallback, null);
    }
    
    void GenerateReport(Employee employee, Action<Exception> errorCallback)
    {
        try
        {
            //do your dirty work
        }
        catch(Exception ex)
        {
            //execute the delegate, which will re-execute itself on the UI 
            //thread if necessary. You're basically rethrowing the exception 
            //"sideways" to the UI thread, rather than up the call stack.
            errorCallback(ex);
        }
    }
