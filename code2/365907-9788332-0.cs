    using (MemoryStream mems = new MemoryStream())
    {
        // Store data in MemoryStream
        // It's searchable which may be required
        // ...
        using (TcpClient tcp = newTcpClient())
        {
            using (NetworkStream ns = tcp.GetStream())
            {
                ns.WriteByte((int)'a'); // Store data type header for type 'a'
                mems.WriteTo(ns); // Write serialized data to network
            }
        }
    }
