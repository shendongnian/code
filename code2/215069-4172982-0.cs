    String ipRange = "1-7.3-8.12-94.14";
    String[] ipParts = ipRange.Split('.');
    if (ipParts.Length < 4)
        throw new FormatException();
    byte [] start = new byte [4];
    byte [] stop = new byte [4];
    for (int i = 0; i <4; i++)
    {
        string[] rangeParts = ipParts[i].Split('-');
        
        if (rangeParts.Length<1 || rangeParts.Length>2)
            throw new FormatException();
        start[i] = byte.Parse(rangeParts[0]);
        stop[i] = (rangeParts.Length == 1) ? start[i] : byte.Parse(rangeParts[1]);
    }
    List<IPAddress> ips = new List<IPAddress>();
    for(byte i0 = start[0]; i0<=stop[0];i0++)
    {
        for(byte i1 = start[1]; i1<=stop[1];i1++)
        {
            for(byte i2 = start[2]; i2<=stop[2];i2++)
            {
                for(byte i3 = start[3]; i3<=stop[3];i3++)
                {
                    ips.Add(new IPAddress(new byte[] { i0, i1, i2, i3 }));
                }
            }
        }
    }
