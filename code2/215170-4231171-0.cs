          private IPEndPoint ipendpoint;
          private string command;
          private string response;
    
          private void worker()
          {
            UdpClient client = new UdpClient();
            var result1 = string.Empty;
            var result2 = string.Empty;
            bool sent = false;
            bool DoubleTrame = false;
            Byte[] bufferTemp = Encoding.ASCII.GetBytes(this.command);
            Byte[] bufferSend = new Byte[bufferTemp.Length + 5];
            Byte[] bufferRec;
            Byte[] bufferRec2;
    
            bufferSend[0] = Byte.Parse("255");
            bufferSend[1] = Byte.Parse("255");
            bufferSend[2] = Byte.Parse("255");
            bufferSend[3] = Byte.Parse("255");
            bufferSend[4] = Byte.Parse("00");
    
            for (int i = 0; i < bufferTemp.Length; i++)
            {
                bufferSend[i + 5] = bufferTemp[i];
            }
    
            while (!sent)
            {
                client.Send(bufferSend, bufferSend.Length, ipendpoint);
                Thread.Sleep(200);
                if (client.Available > 0)
                {
                    sent = true;
                    if (client.Available > 1200)
                    {
                        DoubleTrame = true;
                    }
                }
            }
            bufferRec = client.Receive(ref ipendpoint);
            if (DoubleTrame)
            {
                bufferRec2 = client.Receive(ref ipendpoint);
                result2 = Encoding.ASCII.GetString(bufferRec2);
                if (result2.Contains("\n\n"))
                {
                    result2 = result2.Remove(result2.IndexOf("\n\n"));
                }
                result2 = result2.Substring(12);
            }
            result1 = Encoding.ASCII.GetString(bufferRec);
            this.response = result1 + result2;
          }
