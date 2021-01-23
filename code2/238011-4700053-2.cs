    public byte[] ushort2byteArr(ushort[] arr) {
      System.IO.MemoryStream ms = new System.IO.MemoryStream(); 
      System.IO.BinaryWriter bw = new System.IO.BinaryWriter(ms);
      for (int i = 0; i < arr.Length-1;) { // check upper limit! 
          // following is wrong! must extend this to pack 8 12 bit words into 3 uint32! 
          UInt32 tmp = arr[i++] | (arr[i++] << 12) ... ; 
          bw.Write(tmp);
      }
      return ms.ToArray(); 
    }
