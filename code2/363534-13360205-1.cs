    TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] message = new byte[4096];
            int bytesRead;
            while (true)
            {
                bytesRead = 0;
                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }
                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }
                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
                House house = DeserializeFromXml<House>(encoder.GetString(message, 0, bytesRead));
                //Send Message Back
                byte[] buffer = encoder.GetBytes("Hello Client - " + DateTime.Now.ToLongTimeString());
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
            tcpClient.Close();
        }
