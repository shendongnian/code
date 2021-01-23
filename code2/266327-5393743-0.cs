    class BufferItem
    {
        public string Data { get; private set; }
        public TimeSpan ReleaseTime { get; private set; }
        public BufferItem(string d, TimeSpan ts)
        {
            data = d;
            ReleaseTime = ts;
        }
    }
