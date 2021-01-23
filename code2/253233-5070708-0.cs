    public class MyBinaryReader : BinaryReader
    {
        public MyBinaryReader(byte[] input) : base(new MemoryStream(input))
        {
        }
      
        public override string ReadString()
        {
             // read null-terminated string
        }
    }
