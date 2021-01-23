static readonly ManualResetEvent resetEvent = new ManualResetEvent(false);
static void Main(string[] args)
        {
          ...
          auBackend.UpToDate += auBackend_UpToDate;
          ...
          // Blocks until "resetEvent.Set()" on another thread
          resetEvent.WaitOne();
    
        }
static void auBackend_UpToDate(object sender, SuccessArgs e)
        {
            resetEvent.Set();
        }
    </pre>
Thanks for the responses. 
If anyone ever needs a very versatile application updater solution, I would suggest the wyBuild/wyUpdate package.  
Njoy!
