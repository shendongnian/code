        public void Listen(string PipeName)
        {
            try
            {
                // Set to class level var so we can re-use in the async callback method
                _pipeName = PipeName;
                // Create the new async pipe 
                NamedPipeServerStream pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.In, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
                // Wait for a connection
                pipeServer.BeginWaitForConnection(new AsyncCallback(WaitForConnectionCallBack), pipeServer);
            }
            catch (Exception oEX)
            {
                Debug.WriteLine(oEX.Message);
            }
        }
        private void WaitForConnectionCallBack(IAsyncResult iar)
        {
            NamedPipeServerStream pipeServer = (NamedPipeServerStream)iar.AsyncState;
            try
            {
                // End waiting for the connection
                pipeServer.EndWaitForConnection(iar);
                byte[] buffer = new byte[255];
                // Read the incoming message
                pipeServer.Read(buffer, 0, 255);
                // Convert byte buffer to string
                string stringData = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                Debug.WriteLine(stringData + Environment.NewLine);
                // Pass message back to calling form
                PipeMessage.Invoke(stringData);
                // Kill original server and create new wait server
                pipeServer.Close();
                pipeServer = null;
                pipeServer = new NamedPipeServerStream(_pipeName, PipeDirection.In, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
                // Recursively wait for the connection again and again....
                pipeServer.BeginWaitForConnection(new AsyncCallback(WaitForConnectionCallBack), pipeServer);
            }
            catch (Exception ex)
            {
                string ctch = ex.ToString();
                return;
            }
        }
