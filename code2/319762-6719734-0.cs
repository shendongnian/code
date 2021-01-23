    struct TwoNybbles
    {
        private readonly byte b;
        public byte High { get { return (byte)(b >> 4); } }
        public byte Low { get { return (byte)(b & 0x0F); } {
        public TwoNybbles(byte high, byte low)
        {
            this.b = (byte)((high << 4) | (low & 0x0F));
        }
  
