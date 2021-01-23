    using (MemoryStream ms = new MemoryStream())
    {
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(ms,SerializableClassOfDoom);
        byte[] messsize = BitConverter.GetBytes(ms.Length);
        NetworkStream ns = Sock.GetStream();
        ns.Write(messsize, 0, messsize.Length);
        ms.Position = 0; // not sure if needed, doc for CopyTo unclear
        ms.CopyTo(ns); 
    }
