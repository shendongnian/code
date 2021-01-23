    List<byte> lByte = new List<byte>();
    using (StreamReader sr = new StreamReader(myRequest.GetResponse().GetResponseStream()))
    {
        while (sr.Peek() >= 0)
        {
            lByte.Add((byte)sr.Read());
        }
    }
