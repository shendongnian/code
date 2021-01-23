    // add these to your using statments
    using System.IO.Pipes;
    using System.Threading;
    // NOTE: take all the async stuff with a grain of salt; this should give you a
    // basic idea but there's no way I've gotten it right without actually testing
    // and debugging everything. See the link 
    // http://stackoverflow.com/questions/6710444/named-pipes-server-read-timeout
    // for some information on why it has to be done this way: basically timeout
    // is not supported for named pipe server streams.
    public class ExchangeDataLocalMachineDispatcher :
       ExchangeDataDispatcher
    {
        // see http://www.switchonthecode.com/tutorials/dotnet-35-adds-named-pipes-support
        // for some info on named pipes in .NET
        public ExchangeDataLocalMachineDispatcher(
            ExchangeCommonDataSource parDataSource, 
            NamedPipeServerStream ServerPipe
        ) :
          base(parDataSource)
        {
            myPipe = ServerPipe;
            // do any extra initialization, etc. here, negotiation for instance
            StartPipeThread();
        }
        private NamedPipeServerStream myPipe;
        private ExchangeCommonDataSource myDataSource;
        // assuming you have PipeMessage defined and that your handler
        // fills them in.
        private List<PipeMessage> myOutgoingMessages = 
            new List<PipeMessage>(); 
        private Thread myPipeThread;
        private bool EndPipeListener = false;
        private AutoResetEvent myWaitEvent = null;
        private AutoResetEvent myDataReadyToGoEvent = null;
        // set this to something reasonable for the response timeout
        private int WaitTimeout = 10000; 
        // example: at least every minute there should be data to send
        private int WaitForDataToSendTimeout = 60000; 
        private void StartPipeThread()
        {
            IAsyncResult LastResult = null;
            Action<IAsyncResult> WaitForResult =
                (a) =>
                {
                    LastResult = a;
                    myWaitEvent.Set();
                }
           
            myPipeThread = new System.Threading.ThreadStart(
            () => 
            {
              try
              {
                  myWaitEvent = new AutoResetEvent(false);
                  myPipe.BeginWaitForConnection(
                      WaitForResult, null
                  );
                  
                  bool TimedOut = !myWaitEvent.WaitOne(WaitTimeout);
                  if (TimedOut || !LastResult.IsCompleted)
                      throw new Exception("Error: pipe operation error.");
                  while (!EndPipeListener)
                  {
                      byte[] Response = myPipe.BeginRead(
                         WaitForResult, null
                      );
        
                      myWaitEvent.WaitOne(WaitTimeout);
                      if (TimedOut || !LastResult.IsCompleted)
                          throw new Exception("Error: pipe operation error.");
                      // another assumed function to handle ACKs and such
                      HandleResponse(Response);
                      myWaitEvent.Set();
                      // now wait for data and send
                      bool TimedOut = 
                          myDataReadyToGoEvent.WaitOne(WaitForDataToSendTimeout);
 
                      if (TimedOut || !LastResult.IsCompleted)
                          throw new Exception("Error: no data to send.");
                      // an assumed function that will pull the messages out of
                      // the outgoing message list and send them via the pipe
                      SendOutgoingMessages();
                      myDataReadyToGoEvent.Set();
                  }
                  myWaitEvent.Set();
              }
              finally
              {
                  // here you can clean up any resources, for instance you need
                  // to dispose the wait events, you can leave the pipe for the
                  // DispatcherShutdown method to fire in case something else
                  // wants to handle the error and try again... this is all
                  // fairly naive and should be thought through but I wanted  
                  // to give you some tools you can use.
                  // can't remember if you're supposed to use .Close
                  // .Dispose or both off the top of my head; I think it's
                  // one or the other.
                  myWaitEvent.Dispose();
                  myDataReady.Dispose();
                  myWaitEvent = null;
                  myDataReady = null;     
              }
            }
            );
        }
        protected PipeMessage[] ConstructEventMessage(e EventArgs)
        {
            // actually we're not using the event args here but I left it
            // as a placeholder for if were using the derived ones.
            return 
                PipeMessage.CreateMessagesFromData(
                    myDataSource.GetMessageData()
                );
        }
 
        protected override void  DispatcherHandleDataReceived(e EventArgs)
        {
            // create a packet to send out; assuming that the 
            // ConstructEventMessage method is defined
            myOutgoingMessages.Add(ConstructEventMessage(e));
        }
        protected override void DispatcherShutdown()
        {
            // this is called from the base class in the Dispose() method
            // you can destroy any remaining resources here
            if (myWaitEvent != null)
            {
                myWaitEvent.Dispose();
            }
            // etc. and
            myPipe.Dispose();
        }
        // you could theoretically override this method too: if you do, be
        // sure to call base.Dispose(disposing) so that the base class can
        // clean up if resources are there to be disposed. 
        // protected virtual void Dispose(bool disposing)
        // {
        //     // do stuff
        //     base.Dispose(disposing);
        // }
    }
