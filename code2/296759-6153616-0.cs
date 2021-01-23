    public void ServerStateChanged()         
    {
        if(this.InvokeRequired)
        {
            this.Invoke(new delegate
            {
                ServerStateChanged();
            }
            return;
        }
        if (this.Focused)                 
        {                     
            this.noConnectionsLL.Text = this.tcpServer.ClientsCount.ToString();
        }             
    }             
