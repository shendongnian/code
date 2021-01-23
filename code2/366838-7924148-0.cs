            while (true)
            {
                mySocket = myListener.AcceptSocket();
                Console.WriteLine("\r\nsocket type = {0}", mySocket.SocketType);
                if (mySocket.Connected)
                {
                 byte[] receive = new byte[1024];
                 mySocket.Receive(receive, 1024, 0);
                 string sBuffer = Encoding.ASCII.GetString(receive);
                }
           }
