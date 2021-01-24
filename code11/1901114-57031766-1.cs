        /// <summary>
        /// The thread function that handles data received from client connected to this server
        /// </summary>
        void ReceivePoller()
        {
            // Connect the socket to the remote endpoint. Catch any errors.
            try
            {
                var bytes = new byte[Server.PackageSize];
                var package = new List<byte>();
                var bytesRec = -1;
                var handshakesend = false;
                List<byte> blob = new List<byte>();
                do
                {
                    // Get the package
                    if (Server.InputUseSSL)
                        bytesRec = SslStream.Read(bytes, 0, bytes.Length);
                    else
                        bytesRec = NetworkStream.Read(bytes, 0, bytes.Length);
                    // Clean the array
                    byte[] cleanbytes = new byte[bytesRec];
                    Buffer.BlockCopy(bytes, 0, cleanbytes, 0, bytesRec);
                    // Check if handshaken
                    if (!handshakesend)
                    {
                        var data = System.Text.Encoding.Default.GetString(cleanbytes);
                        if (Server.Debug)
                            Context.Logging.Message(IpAddress + "<-- " + data.Length + " B: " + data);
                        if (new System.Text.RegularExpressions.Regex("^GET").IsMatch(data))
                        {
                            const string eol = "\r\n"; // HTTP/1.1 defines the sequence CR LF as the end-of-line marker
                            var response = "HTTP/1.1 101 Switching Protocols" + eol
                                + "Connection: Upgrade" + eol
                                + "Upgrade: websocket" + eol
                                + "Sec-WebSocket-Accept: " + Convert.ToBase64String(
                                    System.Security.Cryptography.SHA1.Create().ComputeHash(
                                        Encoding.UTF8.GetBytes(
                                            new System.Text.RegularExpressions.Regex("Sec-WebSocket-Key: (.*)").Match(data).Groups[1].Value.Trim() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"
                                        )
                                    )
                                ) + eol
                                + eol;
                            Byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                            NetworkStream.Write(responseBytes, 0, responseBytes.Length);
                            
                            if (Server.Debug)
                                Context.Logging.Message(IpAddress + "--> " + response.Length + " B: " + response);
                            handshakesend = true;
                        }
                        else
                        {
                            // Shut it down man!
                            Stop();
                        }
                    }
                    else
                    {
                        blob.AddRange(cleanbytes);
                        if (!NetworkStream.DataAvailable)
                        {
                            // Decode the received data
                            var data = DecodedData(blob.ToArray(), blob.Count);
                            if (Server.Debug)
                                Context.Logging.Message(IpAddress + "<-- " + data.Length + " B: " + data);
                            // Process message
                            Server.ProcessMessage(this, data);
                            // Reset the blob
                            blob.Clear();
                        }
                    }
                } while (bytesRec != 0 && Socket.Connected && !IsAlreadyStopped && !StopSwitch);
            }
            catch (System.IO.IOException ex)
            {
            }
            catch (SocketException ex)
            {
            }
            catch (Exception ex)
            {
                // When the connection is lost the waiting thread will be ended with a exception. 
                // We use this to notify the other connection (LAN) that the connection has ended.
                // So there is no need to see this in our error logging.
                if (Server.Debug) Context.Logging.Message(IpAddress + " Client.DataReceive ERROR" + Environment.NewLine + ex.ToString());
            }
            // Stop the client just in case
            Stop();
        }
        /// <summary>
        /// Will decode the received byte array from the websocket
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        string DecodedData(byte[] buffer, int length)
        {
            byte b = buffer[1];
            int dataLength = 0;
            int totalLength = 0;
            int keyIndex = 0;
            if (b - 128 <= 125)
            {
                dataLength = b - 128;
                keyIndex = 2;
                totalLength = dataLength + 6;
            }
            if (b - 128 == 126)
            {
                dataLength = BitConverter.ToInt16(new byte[] { buffer[3], buffer[2] }, 0);
                keyIndex = 4;
                totalLength = dataLength + 8;
            }
            if (b - 128 == 127)
            {
                dataLength = (int)BitConverter.ToInt64(new byte[] { buffer[9], buffer[8], buffer[7], buffer[6], buffer[5], buffer[4], buffer[3], buffer[2] }, 0);
                keyIndex = 10;
                totalLength = dataLength + 14;
            }
            if (totalLength > length)
                throw new Exception("The buffer length is small than the data length");
            byte[] key = new byte[] { buffer[keyIndex], buffer[keyIndex + 1], buffer[keyIndex + 2], buffer[keyIndex + 3] };
            int dataIndex = keyIndex + 4;
            int count = 0;
            for (int i = dataIndex; i < totalLength; i++)
            {
                buffer[i] = (byte)(buffer[i] ^ key[count % 4]);
                count++;
            }
            return Encoding.ASCII.GetString(buffer, dataIndex, dataLength);
        }
        /// <summary>
        /// Function used by the LAN receive data thread
        /// </summary>
        /// <param name="data">Data to send</param>
        public void SendData(string data)
        {
            try
            {
                var bytes = Encoding.UTF8.GetBytes(data);
                SendData(bytes, bytes.Length);
            }
            catch (Exception ex)
            {
                if (Server.Debug) Context.Logging.Warning(ex);
            }
        }
        /// <summary>
        /// Function used by the LAN receive data thread
        /// </summary>
        /// <param name="bytes">Data to send</param>
        /// <param name="length">Length of the data to send</param>
        public void SendData(byte[] bytes, int length)
        {
            try
            {
                if (!IsAlreadyStopped && !StopSwitch)
                {
                    if (Server.InputUseSSL)
                        SslStream.Write(bytes);
                    else
                        NetworkStream.Write(bytes, 0, length);
                    if (Server.Debug) Context.Logging.Message(IpAddress + "--> " + bytes.Length + " B: " + System.Text.Encoding.Default.GetString(bytes));
                }
            }
            catch (Exception ex)
            {
                if (Server.Debug) Context.Logging.Warning(ex);
            }
        }
