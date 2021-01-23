    public class ClassA
    {
        private Socket socket;
        private Thread thread;
    
        public void Connect()
        {
            socket = new Socket(...);
            socket.Connect(...);
            thread = new Thread(DoWork);
            thread.Start();
        }
        public void Disconnect()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            thread.Join();
        }
        private void DoWork()
        {
            try
            {
                while (true)
                {
                    int received = socket.Receive(buffer, ...);
                    if (received == 0)
                    {
                        break;
                    }
                    // process buffer
                    ...
                }
            }
            catch (SocketException)
            {
                ...
            }
        }
    }
