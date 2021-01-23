       private string getHTTP(string url)
        {
            TcpClient clientSocket = new TcpClient();
            NetworkStream networkStream = null;
            long port = 7777;
            try
            {
                try
                {
                    clientSocket.Connect(url,port );
                }
                catch { MessageBox.Show("Server is not Working", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning); return "Server is not working"; }
                byte[] sendbyte = Encoding.ASCII.GetBytes(url);
                networkStream = clientSocket.GetStream();
                networkStream.Write(sendbyte, 0, sendbyte.Length);
                networkStream.Flush();
            }
            catch { MessageBox.Show("Streaming Error", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning); return "Error"; }
            // receive Message from DNS Server
            byte[] receivedata = new byte[clientSocket.ReceiveBufferSize];
            networkStream.Read(receivedata, 0, clientSocket.ReceiveBufferSize);
            string urlnew = Encoding.ASCII.GetString(receivedata);
            return urlnew;
        }
