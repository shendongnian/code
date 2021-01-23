    int targetLength = 33554432;
    string filler = "hello, world";
    byte[] target = new byte[targetLength];
    // Convert filler to bytes. Can use other encodings here.
    // I am using ASCII to match C++ output.
    byte[] fillerBytes = Encoding.ASCII.GetBytes(filler);
    //byte[] fillerBytes = Encoding.Unicode.GetBytes(filler);
    //byte[] fillerBytes = Encoding.UTF8.GetBytes(filler);
    int position = 0;
    while((position + fillerBytes.Length) < target.Length)
    {
        fillerBytes.CopyTo(target, position);
        position += fillerBytes.Length;
    }
    // At this point, need to possibly do a partial copy.
    if (position < target.Length)
    {
        int bytesNecessary = target.Length - position;
        Array.Copy(fillerBytes, 0, target, position, bytesNecessary);
    }
