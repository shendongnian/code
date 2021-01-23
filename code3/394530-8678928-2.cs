    byte[] test = new byte[10];
    using (BinaryReader reader = new BinaryReader(new FileStream(file, FileMode.Open)))
    {
        reader.BaseStream.Seek(50, SeekOrigin.Begin);
        reader.Read(test, 0, 10);
    }
