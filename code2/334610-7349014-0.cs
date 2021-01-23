           using (NetworkStream ns = _client.GetStream())
           using (MemoryStream ms = new MemoryStream())
           {
               ns.Write(messageBytes, 0, messageBytes.Length);
               for (int i = 0; i < 50; i++)
               {
                   Thread.Sleep(20);
                   byte[] buffer = new byte[16 * 1024];
                   int bytes;
                   while ((bytes = ns.Read(buffer, 0, buffer.Length)) > 0)
                   {
                       ms.Write(buffer, 0, bytes);
                   }
                   byte[] data = ms.ToArray();
                   response += Encoding.ASCII.GetString(data, 0, data.Length);
               }
