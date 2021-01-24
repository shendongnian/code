    message.Write(STX, 0 , 1);
    message.Write(bytes1, 0, bytes1.Length);
    message.Write(FS, 0 , 1);
    message.Write(bytes2, 0, bytes2.Length);
    message.Write(FS, 0 , 1);
    message.Write(bytes3, 0, bytes3.Length);
    message.Write(EXT, 0 , 1);
