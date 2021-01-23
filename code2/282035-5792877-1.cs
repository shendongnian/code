    System.IO.MemoryStream ms = new System.IO.MemoryStream(array);
    System.IO.BinaryReader br = new System.IO.BinaryReader(ms);
    int value = br.ReadInt32();
    int value2 = br.ReadInt32();
    int value3 = br.ReadInt32();
