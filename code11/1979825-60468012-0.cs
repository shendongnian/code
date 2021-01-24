        public string Read()
        {
            if (IsConnected)
            {
                byte[] buffer = new byte[Tcp.ReceiveBufferSize];//create a byte array
                int bytesRead = stream.Read(buffer, 0, Tcp.ReceiveBufferSize);//read count
                string str = Encoding.ASCII.GetString(buffer, 0, bytesRead);//convert to string
                return str;
            }
            else
            {
                throw new Exception("Client " + ID + " is not connected!");
            }
        }
        public void Write(string str)
        {
            if (IsConnected)
            {
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(str);
                stream.Write(bytesToSend, 0, bytesToSend.Length);
            }
            else
            {
                throw new Exception("Client " + ID + " is not connected!");
            }
        }
