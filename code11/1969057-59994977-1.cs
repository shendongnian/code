    enum ServerStatus { Available, Refused, TimeOut };
    private async void btnTest_Click(object sender, EventArgs e)
    {
        int timeOut = 5000;
        while (true)
        {
            var cts = new CancellationTokenSource(timeOut);
            var ct = cts.Token;
            var t = await Task.Run<ServerStatus>(() => 
            {
                try
                {
                    using (TcpClient client = new TcpClient())
                    {
                        client.ConnectAsync("192.168.1.88", 9999).Wait(timeOut);
                        ct.ThrowIfCancellationRequested();
                        client.Close();
                        return ServerStatus.Available;
                    }
                }
                catch (AggregateException ex) when (ex.InnerException.GetType() == typeof(SocketException)) 
                {
                    if (((SocketException)ex.InnerException).SocketErrorCode == SocketError.ConnectionRefused)
                        return ServerStatus.Refused;
                    else
                        throw;
                }
                catch (OperationCanceledException)
                {
                    return ServerStatus.TimeOut;
                }
            }, ct);
            switch (t)
            {
                case ServerStatus.Available:
                    listBox1.Items.Add($"{DateTime.Now.ToString()} Server available"); ;
                    break;
                case ServerStatus.Refused:
                    listBox1.Items.Add($"{DateTime.Now.ToString()} Server refused connection.");
                    break;
                case ServerStatus.TimeOut:
                    listBox1.Items.Add($"{DateTime.Now.ToString()} Server did not respond.");
                    break;
            }
                
            // Wait 1 second before trying the test again
            await Task.Delay(1000);
        }
    }
