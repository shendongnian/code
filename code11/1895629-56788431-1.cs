     byte[] test = new byte[] {1, 7};
     BitArray ba = new BitArray(test);
     StringBuilder sb = new StringBuilder();
     for (int i = 0; i < ba.Length; i++) {
       if (i > 0 && i % 8 == 0)
         sb.Append(' ');
       sb.Append(ba[i] ? '1' : '0');
     }
     Console.Write(sb.ToString());
