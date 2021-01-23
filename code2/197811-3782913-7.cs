    using System.IO;
    
    class EndiannessSample
    {
        static void Main(string[] args)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // write bytes in little-endian format
                ms.WriteByte(0xEB);
                ms.WriteByte(0x03);
                ms.WriteByte(0x00);
                ms.WriteByte(0x00);
                ms.Position = 0;
                using (BinaryReader reader = new BinaryReader(ms))
                {
                    int i = reader.ReadInt32(); // decimal value of i is 1003
                }
            }
        }
    }
