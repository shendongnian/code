    byte[] bytes = BitConverter.GetBytes(41104);
    if (BitConverter.IsLittleEndian)
    {    List<byte> tmp = new List<byte>();
         tmp.AddRange(bytes);
         tmp.Reverse();
         bytes = tmp.ToArray();
    }
