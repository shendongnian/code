    private async void btnTest_Click(object sender, EventArgs e)
    {
        int timeOut = 2000;
            
        while (true)
        {
            using (TcpClient client = new TcpClient())
            {
                var ca = client.ConnectAsync("127.0.0.1", 9999);
                await Task.WhenAny(ca, Task.Delay(timeOut));
                client.Close();
                if (ca.IsFaulted || !ca.IsCompleted)
                    listBox1.Items.Add($"{DateTime.Now.ToString()} Server offline.");
                else
                    listBox1.Items.Add($"{DateTime.Now.ToString()} Server available.");
            }
            // Wait 1 second before trying the test again
            await Task.Delay(1000);
        }
    }
