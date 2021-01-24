    class SynchronizedDATAStructure : DATAStructure
    {
        private readonly object syncRoot = new object();
        public int MessageCount { get; private set; }
        public override void Write(Message msg)
        {
            lock (syncRoot)
            {
                base.Write(msg);
                MessageCount++;
                Monitor.Pulse(syncRoot);
            }
        }
        public override Message Read()
        {
            lock (syncRoot)
            {
                while (MessageCount <= 0)
                {
                    Monitor.Wait(syncRoot);
                }
                MessageCount--;
                return base.Read();
            }
        }
    }
