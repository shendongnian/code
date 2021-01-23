    // Writing
    BinaryWriter writer = new BinaryWriter(new FileStream(...));
    int[] intArr = new int[1000];
    
    writer.Write(intArr.Length);
    for (int i = 0; i < intArr.Length; i++)
        writer.Write(intArr[i]);
                
    // Reading
    BinaryReader reader = new BinaryReader(new FileStream(...));
    int[] intArr = new int[reader.ReadInt32()];
                
    for (int i = 0; i < intArr.Length; i++)
        intArr[i] = reader.ReadInt32();
                
    // Writing, method 2
    BinaryWriter writer = new BinaryWriter(new FileStream(...));
    int[] intArr = new int[1000];
    byte[] byteArr = new byte[intArr.Length * sizeof(int)];
    Buffer.BlockCopy(intArr, 0, byteArr, 0, intArr.Length * sizeof(int));
    
    writer.Write(intArr.Length);
    writer.Write(byteArr);
                
    // Reading, method 2
    BinaryReader reader = new BinaryReader(new FileStream(...));
    int[] intArr = new int[reader.ReadInt32()];
    byte[] byteArr = reader.ReadBytes(intArr.Length * sizeof(int));
    Buffer.BlockCopy(byteArr, 0, intArr, 0, intArr.Length * sizeof(int));
