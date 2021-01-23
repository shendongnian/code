    class Packet
    {
        private Header header;
        public Header Header
        {
            get { return this.header; }
            set
            {
                this.header = value;
                this.header.Packet = this;
            }
        }
    }
    class Header
    {
        public Packet Packet { get; set; }
    }
