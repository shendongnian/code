    // create new array
    byte[] key = new byte[salt.Length + 4];
    // copy salt
    Array.Copy(salt, key, salt.Length);
    // create array from integer
    byte[] g = BitConverter.GetBytes(1);
    if (BitConverter.IsLittleEndian) {
      Array.Reverse(g);
    }
    // copy integer array
    Array.Copy(g, 0, key, salt.Length, 4);
