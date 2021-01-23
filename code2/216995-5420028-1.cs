    int Count1Xor(byte[] a1, byte[] a2)
    {
      int count = 0;
      for (int i = 0; i < Math.Min(a1.Length, a2.Length); i++)
      {
        byte b = (byte)((int)a1[i] ^ (int)a2[i]);
        while (b != 0)
        {
          count++;
          b = (byte)((int)b & (int)(b - 1));
        }
      }
      return count;
    }
