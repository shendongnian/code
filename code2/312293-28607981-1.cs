    var searchAndReplace = new List<Tuple<byte[], byte[]>>() 
    {
        Tuple.Create(
            BitConverter.GetBytes((UInt32)0xDEADBEEF),
            BitConverter.GetBytes((UInt32)0x01234567)),
        Tuple.Create(
            BitConverter.GetBytes((UInt32)0xAABBCCDD),
            BitConverter.GetBytes((UInt16)0xAFFE)),
    };
    using(var reader =
        new BinaryReader(new FileStream(@"C:\temp\data.bin", FileMode.Open)))
    {
        using(var writer =
            new BinaryWriter(new FileStream(@"C:\temp\result.bin", FileMode.Create)))
        {
            BinaryUtility.Replace(reader, writer, searchAndReplace);
        }
    }
