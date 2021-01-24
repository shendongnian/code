   private bool isWorking = false;
    private async void bt_check_port_Click(object sender, EventArgs e)
    {
      if (!isWorking)
      {
        isWorking = true;
        try
        {
          bt_check_port.Enabled = false;
          bt_check_port.BackColor = SystemColors.Control;
          string ip = tb_ip_test.Text;
          string port = tb_port_test.Text;
          bool portAwailable = await Task.Run<bool>(() =>
            {
              TcpClient tcpClient = new TcpClient();
              try
              {
                tcpClient.Connect(ip, Int32.Parse(port));
                return true;
              }
              catch (Exception)
              {
                return false;
              }
            });
          bt_check_port.BackColor = portAwailable ? Color.Green : Color.Red;
        }
        finally
        {
          isWorking = false;
          bt_check_port.Enabled = true;
        }
      }
    }</code>
