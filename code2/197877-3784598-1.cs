    class PingCollection : Collection<Ping>
    {
        public new void Add(Ping ping)
        {
            ping.PingCompleted += (sender,e) => PingCompleted(sender,e);
            base.Add(ping);
        }
    
        private void PingCompleted(object sender, EventArgs e)
        {
            // do stuff
        }
    }
