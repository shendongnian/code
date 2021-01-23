        private void button1_Click(object sender, EventArgs e)
        {
            channel = new TcpChannel(port);
            Trace.WriteLine("Start Connection received at Server");
            ChannelServices.RegisterChannel(channel, false);
            //Initiate remote service as Marshal
            RemotingServices.Marshal(this, "Server", typeof(Server));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("Stop Connection at Server");
            channel.StopListening(null);
            RemotingServices.Disconnect(this);
            ChannelServices.UnregisterChannel(channel);
            channel = null;
        }
