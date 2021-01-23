    using (MemoryStream ms = new MemoryStream())
    {
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(ms,SerializableClassOfDoom);
        byte[] messsize = BitConverter.GetBytes(ms.Length);
        ms.Write(messsize, 0, messsize.Length);
        ms.Position = 0;
        NetworkStream ns = Sock.GetStream();
        ms.CopyTo(ns);
    }
