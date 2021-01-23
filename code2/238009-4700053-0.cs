    ushort[] arr = new  ushort[111];
    System.IO.MemoryStream ms = new System.IO.MemoryStream(); 
    System.IO.BinaryWriter bw = new System.IO.BinaryWriter(ms);
    for (int i = 0; i < arr.Length-1;) {
        UInt32 tmp = arr[i++] | (arr[i++] << 12); 
        bw.Write(tmp);
    }
    return ms.ToArray(); 
