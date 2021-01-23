    public class Client
    {
        Socket              m_Socket;
        EventWaitHandle     m_WaitHandle;
        readonly object     m_Locker;
        Queue<IEvent>       m_Tasks;
        Thread              m_Thread;
        Thread              m_ReadThread;
        public Client()
        {
            m_WaitHandle = new AutoResetEvent(false);
            m_Locker = new object();
            m_Tasks = new Queue<IEvent>();
            m_Thread = new Thread(Run);
            m_Thread.IsBackground = true;
            m_Thread.Start();
        }
        public void EnqueueTask(IEvent task)
        {
            lock (m_Locker)
            {
                m_Tasks.Enqueue(task);
            }
            m_WaitHandle.Set();
        }
        private void Run()
        {
            while (true)
            {
                IEvent task = null;
                lock (m_Locker)
                {
                    if (m_Tasks.Count > 0)
                    {
                        task = m_Tasks.Dequeue();
                        if (task == null)
                        {
                            return;
                        }
                    }
                }
                if (task != null)
                {
                    task.DoTask(this);
                }
                else
                {
                    m_WaitHandle.WaitOne();
                }
            }
        }
        public void Connect(string hostname, int port)
        {
            try
            {
                m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress[] IPs = Dns.GetHostAddresses(hostname);
                m_Socket.BeginConnect(IPs, port, new AsyncCallback(ConnectCallback), m_Socket);
            }
            catch (SocketException)
            {
                m_Socket.Close();
                OnConnect(false, "Unable to connect to server.");
            }
        }
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                socket.EndConnect(ar);
                OnConnect(true, "Successfully connected to server.");
                m_ReadThread = new Thread(new ThreadStart(this.ReadThread));
                m_ReadThread.Name = "Read Thread";
                m_ReadThread.IsBackground = true;
                m_ReadThread.Start();
            }
            catch (SocketException)
            {
                m_Socket.Close();
                OnConnect(false, "Unable to connect to server.");
            }
        }
        void ReadThread()
        {
            NetworkStream networkStream = new NetworkStream(m_Socket);
            StreamReader reader = new StreamReader(networkStream);
            while (true)
            {
                try
                {
                    String message = reader.ReadLine();
                    // To keep the code thread-safe, enqueue a task in the CLient class thread to parse the message received.
                    EnqueueTask(new ServerMessageEvent(message));
                }
                catch (IOException)
                {
                    // The code will reach here if the server disconnects from the client. Make sure to cleanly shutdown...
                    Disconnect();
                    break;
                }
            }
        }
        ... Code for sending/parsing the message in the Client class thread.
    }
