    //Create array lookup table
    List<byte[]> array = new List<byte[]>(25500);
    for (int i = 0; i < 25500; i++)
    {
        byte bValue = (byte)i;
        byte[] b = new byte[3] { bValue, bValue, bValue };
        array.Add(b);
    }
