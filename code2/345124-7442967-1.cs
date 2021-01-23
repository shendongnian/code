           TcpClient tc = new TcpClient();
           try
           {
               tc.Connect(<server ipaddress>, <port number>);
               bool stat = tc.Connected;
               if (stat)
                   MessageBox.Show("Connectivity to server available."); 
               tc.Close();
           }
           catch(Exception ex)
           {
               MessageBox.Show("Not able to connect : " + ex.Message);
               tc.Close();
           }
