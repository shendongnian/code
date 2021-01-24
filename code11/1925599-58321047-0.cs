void Initialize_UDP()
    {
        UdpClient udpClient = new UdpClient();
        UdpClient r_UdpClient = new UdpClient(15001);
        IPEndPoint sender = default(IPEndPoint);
        ManualResetEventSlim receive = new ManualResetEventSlim(true);
        Task.Run(() => UDP_Transmit());
    }
async void UDP_Transmit()
        {
            byte[] frame;
            SelectFrameQueue(selector);
            udpClient = new UdpClient(15001);
            udpClient.EnableBroadcast = true;
            udpClient.BeginReceive(new AsyncCallback(UDP_Receive), udpClient);
            while (true)
            {
                for (int i = 0; i < frame_Queue.Length; i++)
                {                    
                        frame = FrameGenerator(frame_Queue[i]);  //Generates Frames
                        try
                        {
                            udpClient.Send(frame, frame.Length, "192.168.4.255", 15000);
                        }
                        catch (SocketException)
                        {
                            Log.Debug("Error", "Socket Exception");
                        }
                        if(!receive.Wait(10000))   //Receive Timeout
                        {
                            RunOnUiThread(() =>
                            {
                                ShowToast("Connection Timeout. Please check device");
                            });
                        };
                        await Task.Delay(update_delay);    //To release pressure from H/W
                        receive.Reset();                        
                }                             
            }
        }
void UDP_Receive(IAsyncResult result)
        {
            receive.Set();
            r_UdpClient = result.AsyncState as UdpClient;
            data = r_UdpClient.EndReceive(result, ref sender);
            RunOnUiThread(() =>
            {               
                Update_UI(data);                            
            });
            r_UdpClient.BeginReceive(new AsyncCallback(UDP_Receive), r_UdpClient);            
        }
