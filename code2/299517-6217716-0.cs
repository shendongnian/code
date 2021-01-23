    [WebService]
    public class AsyncWebService : System.Web.Services.WebService
    {
    public delegate string LengthyProcedureAsyncStub(
        int milliseconds, MyState state);
    public string LengthyProcedure(int milliseconds, MyState state) 
    { 
        while(state.Abort == false)
        {
              //Do your work.  Check periodically for an abort
        }
        return state.Abort ? "Aborted" : "Success"; 
    }
    //This state object is what you can use to track invocations of your method
    //You'll need to store it in a thread safe container.  Add it to the container in the Begin method and remove it in the end method.  While it's in the container other web methods can find it and use it to monitor or stop the executing job.
    public class MyState 
    { 
        public Guid JobID = Guid.NewGuid();
        public object previousState; 
        public LengthyProcedureAsyncStub asyncStub; 
        public bool Abort = false;
    }
    [ System.Web.Services.WebMethod ]
    public IAsyncResult BeginLengthyProcedure(int milliseconds, 
        AsyncCallback cb, object s)
    {
        LengthyProcedureAsyncStub stub 
            = new LengthyProcedureAsyncStub(LengthyProcedure);
        MyState ms = new MyState();
        ms.previousState = s; 
        ms.asyncStub = stub;
        //Add to service wide container
        return stub.BeginInvoke(milliseconds, cb, ms);
    }
  
    [ System.Web.Services.WebMethod ]
    public string EndLengthyProcedure(IAsyncResult call)
    {
        //Remove from service wide container
        MyState ms = (MyState)call.AsyncState;
        return ms.asyncStub.EndInvoke(call);
    }
    [WebMethod]
    public void StopJob(Guid jobID)
    {
         //Look for the job in the service wide container
         MyState state = GetStateFromServiceWideContainer(jobID);
         state.Abort = true;
    }
    }
