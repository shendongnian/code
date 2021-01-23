        public class PipeServer
        {
            bool running;
            Thread runningThread;
            EventWaitHandle terminateHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            public string PipeName { get; set; }
    
            void ServerLoop()
            {
                while (running)
                {
                    ProcessNextClient();
                }
    
                terminateHandle.Set();
            }
    
            public void Run()
            {
                running = true;
                runningThread = new Thread(ServerLoop);
                runningThread.Start();
            }
    
            public void Stop()
            {
                running = false;
                terminateHandle.WaitOne();
            }
    
            public virtual string ProcessRequest(string message)
            {
                return "";
            }
    
            public void ProcessClientThread(object o)
            {
                NamedPipeServerStream pipeStream = (NamedPipeServerStream)o;
              
                //TODO FOR YOU: Write code for handling pipe client here
                pipeStream.Close();
                pipeStream.Dispose();
            }
    
            public void ProcessNextClient()
            {
                try
                {
                    NamedPipeServerStream pipeStream = new NamedPipeServerStream(PipeName, PipeDirection.InOut, 254);
                    pipeStream.WaitForConnection();
                    
                    //Spawn a new thread for each request and continue waiting
                    Thread t = new Thread(ProcessClientThread);
                    t.Start(pipeStream);
                }
                catch (Exception e)
                {//If there are no more avail connections (254 is in use already) then just keep looping until one is avail
                }
            }
        
