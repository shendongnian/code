    using (BinaryWriter bw = new BinaryWriter(File.OpenWrite("asdf"))
    {
        bw.Write(dFoo);
        bw.Write(BitConverter.GetBytes(dFoo));
    }
