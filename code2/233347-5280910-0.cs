    MemoryStream stream = new MemoryStream(); 
    
    BinaryWriter bw = new BinaryWriter(stream);
    
    bw.Write(35);
    
    // is equivalent to doing:
    
    stream.Write(BitConverter.GetBytes((int)35), 0, 4));
