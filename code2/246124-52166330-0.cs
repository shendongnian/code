    MD5Digest hash = new MD5Digest();
    
    public byte[] Hash(byte[] input)
    {
         hash.BlockUpdate(input, 0, input.Length);
         byte[] result = new byte[hash.GetDigestSize()];
         hash.DoFinal(result, 0);
         return result;
    }
    
    public string Hash(string input)
    {
         var data = System.Text.Encoding.Unicode.GetBytes(input);
         hash.BlockUpdate(data, 0, data.Length);
         byte[] result = new byte[hash.GetDigestSize()];
         hash.DoFinal(result, 0);
    
         return Hex.ToHexString(result).ToUpper();
    }
