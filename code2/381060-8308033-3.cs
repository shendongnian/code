    NetworkStream ns = null;
    using (MemoryStream ms = new MemoryStream())
    {
        try{
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms,SerializableClassOfDoom);
            ms.Position = 0;
            byte[] messsize = BitConverter.GetBytes(ms.Length);
            ms.Write(messsize, 0, messsize.Length);
            ns = Sock.GetStream();
            ms.CopyTo(ns);
            //ms.Close();
        }catch(Exception ex){
            throw;
        }finally{
            ms.Flush();
            if(ns != null)
                ns.Flush();
            ms.Close();
        }
    }
