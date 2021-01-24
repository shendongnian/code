    private void button1_Click(object sender, EventArgs e)
    {
        using (var client = new SshClient("IP", "USER", "PASS"))
        {
            label1.Text = "Status: Initiated restart";
            try
            {
                client.Connect();
                var cmd = client.RunCommand("./server restart && ./server2 restart");
                var result = cmd.Execute();
                client.Disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            label1.Text = "Status: Restart completed";
        }
    }
