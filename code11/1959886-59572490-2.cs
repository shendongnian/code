        private async Task StartServerSideClient(TcpClient tcpClient)
        {
            lbConnectedClients.Items.Add("Client: " + tcpClient.Client.RemoteEndPoint.ToString() + " Connected");
            var s = tcpClient.GetStream();
            var buffer = new byte[1000];
            int bytesRead = 0;
            int bytesWrote = 0;
            while (true)
            {
                int rt = await s.ReadAsync(buffer, 0, buffer.Length);
                if (rt == 0) // If ReadAsync() returns with zero then the underlying stream/socket is closed
                    break;
                bytesRead += buffer.Length;
                var wt = s.WriteAsync(buffer, 0, buffer.Length);
                bytesWrote += buffer.Length;
            }
            lbConnectedClients.Items.Add("Client: " + tcpClient.Client.RemoteEndPoint.ToString() + " Wrote: " + bytesWrote + " Read: " + bytesRead);
            lbConnectedClients.Items.Add("Client: " + tcpClient.Client.RemoteEndPoint.ToString() + " disconnected");
            s.Close();
        }
