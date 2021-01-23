    byte[] data = BitConverter.GetBytes(value);
    // make data big-endian if needed
    if (BitConverter.IsLittleEndian) {
       Array.Reverse(data);
    }
    // first 5 base-64 character always "A" (as first 30 bits always zero)
    // only need to keep the 6 characters (36 bits) at the end
    string base64 = Convert.ToBase64String(data, 0, 8).Substring(5,6);
    
    byte[] data2 = new byte[8];
    // add back in all the characters removed during encoding
    Convert.FromBase64String("AAAAA" + base64 + "=").CopyTo(data2, 0);
    // reverse again from big to little-endian
    if (BitConverter.IsLittleEndian) {
       Array.Reverse(data2);
    }
    long decoded = BitConverter.ToInt64(data2, 0);
