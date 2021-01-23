            string ipAddress = "192.168.1.30";
            int port = 6101;
            string zplImageData = string.Empty;
            //Make sure no transparency exists. I had some trouble with this. This PNG has a white background
            string filePath = @"C:\Users\Path\To\Logo.png";
            byte[] binaryData = System.IO.File.ReadAllBytes(filePath);
            foreach (Byte b in binaryData)
            {
                string hexRep = String.Format("{0:X}", b);
                if (hexRep.Length == 1)
                    hexRep = "0" + hexRep;
                zplImageData += hexRep;
              }
              string zplToSend = "^XA" + "^MNN" + "^LL500" + "~DYE:LOGO,P,P," + binaryData.Length + ",," + zplImageData+"^XZ";
              string printImage = "^XA^FO115,50^IME:LOGO.PNG^FS^XZ";
            try
            {
                // Open connection
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                client.Connect(ipAddress, port);
                // Write ZPL String to connection
                System.IO.StreamWriter writer = new System.IO.StreamWriter(client.GetStream(),Encoding.UTF8);
                writer.Write(zplToSend);
                writer.Flush();
                writer.Write(printImage);
                writer.Flush();
                // Close Connection
                writer.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                // Catch Exception
            }
    
    
