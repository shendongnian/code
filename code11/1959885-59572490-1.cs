        private async Task StartEchoClientAsync()
        {
            using (var tcpClient = new TcpClient("127.0.0.1", 9999))
            {
                lbEchoClients.Items.Add("TcpClient: " + tcpClient.Client.LocalEndPoint + "created.");
                var s = tcpClient.GetStream();
                var buffer = new byte[1000];
                for(var i = 0; i < 10; i++)
                {
                    await Task.Delay(1000);
                    await s.WriteAsync(buffer, 0, buffer.Length);
                    lbEchoClients.Items.Add("Sent Bytes: " + buffer.Length);
                    await s.ReadAsync(buffer, 0, buffer.Length);
                    lbEchoClients.Items.Add("Read Bytes: " + buffer.Length);
                }
                tcpClient.Close();
            }
        }
        private async void btnStartAClient_Click(object sender, EventArgs e)
        {
            await StartEchoClientAsync();
        }
