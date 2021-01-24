        void Start ()
        {
            try
            {
                udp = new UdpClient(LOCA_LPORT);
                udp.Client.ReceiveTimeout = 1000;
                thread = new Thread(new ThreadStart(ThreadMethod));
                thread.Start();
            }
            // If any SocketException is thrown while starting the UDP client
            // it is most probably due to the port already being in use
            catch(SocketException e)
            {
                Debug.LogError("UDP cliente has a SocketException." 
                   + "/nThis is probably caused by the target port already being used by something else." 
                   + "/nMake sure you have only one instance of UDPReceive in your scene and try again", this);
            } 
        }
