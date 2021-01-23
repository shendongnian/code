    byte[] data = new byte[hexString.Length / 2];
    
    for(int i = 0; i < hexString.Length - 1; i += 2)
    {
        data[i / 2] = byte.Parse(hexString.Substring(i, 2));
    }
    
    string output = System.Text.Encoding.ASCII.GetString(data);
