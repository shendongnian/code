    [Serializable]
    public class PacketParseException : Exception
    {
        public byte[] ByteData
        {
            get
            {
                return (byte[])this.Data["ByteData"];
            }
        }
    
        public PacketParseException(string message, byte[] data, Exception inner) : base(message, inner)
        {
            this.Data.Add("ByteData", data);
        }
    }
