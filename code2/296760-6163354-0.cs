        public void ServerStateChanged()  
        {
            this.BeginInvoke((Action)(() =>
            {
                if (this.Focused)
                {
                    this.noConnectionsLL.Text = this.tcpServer.ClientsCount.ToString();
                }     
            }));
        }
