    public List<TcpClient> tcpclnts = new List<TcpClient>();
    int iterations = Decimal.ToInt32(numupdown_iterations.Value);
        private void btn_creatConnections_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < iterations; i++)
            {
                var client = new TcpClient();
                client.Connect("192.168.127.254", 721);
                tcpclnts.Add(client);
            }
        }
        private void btn_delete_connections_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < iterations; i++)
            {
                tcpclnts[x].Close();
            }
        }
