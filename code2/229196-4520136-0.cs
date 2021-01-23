    public struct Packet
    {
        /// <summary>
        /// Constructor for initializing packet
        /// </summary>
        /// <param name="header"></param>
        /// <param name="message"></param>
        public Packet(byte[] header, byte[] message)
            : this()
        {
            this.Header = header;
            this.Message = message;
        }
        // Properties representing each part of the sub-packet parts (can be made private if needed)
        public IEnumerable<byte> Header { get; set; }
        public IEnumerable<byte> Message { get; set; }
        public IEnumerable<byte> StopBit { get { return new byte[1] { 0xFF }; } }
        /// <summary>
        /// Returns the byte representation of the whole packet
        /// </summary>
        public byte[] GetBytes
        {
            get { return Header.Concat(Message).Concat(StopBit).ToArray(); }
        }
    }
