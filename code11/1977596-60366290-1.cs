    BinaryReader reader = new BinaryReader(new FileStream(directory, FileMode.Open));
    byte[] packet = new byte[262];
    // Create and send packet
    for (ushort i = 0; i < 10; i++)
    {
        // Set current packet index
        packet[0] = (byte)i;
        packet[1] = (byte)(i >> 8);
    
        // Copy read buffer starting index 2 
        reader.ReadBytes(256).CopyTo(packet,2); //starting at index 2
    }
