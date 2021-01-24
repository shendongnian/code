    public void RxCallBack(IAsyncResult aResult)
    {
        try
        {
                // Create Local Buffer
                byte[] receivedData = new byte[1500];
                // Create Socket to get received data
                Socket ReceiveSocket = (Socket)aResult.AsyncState;
                // Create Endpoint
                EndPoint epReceive = new IPEndPoint(IPAddress.Any, 0);
                // Extract Data...
                int UDPRxDataLength = ReceiveSocket.EndReceiveFrom(aResult, ref epReceive);
                // Copy Rx Data to Local Buffer
                Array.Copy(SocketLocal.Buffer, receivedData, UDPRxDataLength);
                //Start listening for a new message.
                // Setup for next Packet to be received
                Buffer = new byte[1500];
                SocketLocal.BeginReceiveFrom(Buffer, 0, Buffer.Length, SocketFlags.None, ref epReceive, (RxCallBack), SocketLocal);
            // I process/intepret the received data
            // ...
            // The Sender's IP Address is located in the epReceive Endpoint
            lstBox.Items.Add( "Sender IP " + ((IPEndPoint)epReceive).Address.ToString() );
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }  // End of RxCallBack
