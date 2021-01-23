    class PingCollection : Collection<Ping>
    {
        protected override void InsertItem(int index, Ping item)
        {
            ping.PingCompleted += PingCompleted
            base.InsertItem(index, item);
        }
    
        private void PingCompleted(object sender, EventArgs e)
        {
            // do stuff
        }
    }
