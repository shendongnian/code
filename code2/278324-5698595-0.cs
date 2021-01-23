    public delegate void SocketEventHandler(Socket socket);
        public class CustomSocket : Socket
        {
            private readonly Timer timer;
            private const int INTERVAL = 1000;
    
            public CustomSocket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
                : base(addressFamily, socketType, protocolType)
            {
                timer = new Timer { Interval = INTERVAL };
                timer.Tick += TimerTick;
            }
    
            public CustomSocket(SocketInformation socketInformation)
                : base(socketInformation)
            {
                timer = new Timer { Interval = INTERVAL };
                timer.Tick += TimerTick;
            }
    
            private readonly List<SocketEventHandler> onCloseHandlers = new List<SocketEventHandler>();
            public event SocketEventHandler SocketClosed
            {
                add { onCloseHandlers.Add(value); }
                remove { onCloseHandlers.Remove(value); }
            }
    
            public bool EventsEnabled
            {
                set
                {
                    if(value)
                        timer.Start();
                    else
                        timer.Stop();
                }
            }
    
            private void TimerTick(object sender, EventArgs e)
            {
                if (!Connected)
                    foreach (var socketEventHandler in onCloseHandlers)
                        socketEventHandler.Invoke(this);
            }
        }
