    public string ConvertFromUtf8(byte[] bytes)
    {
      var enc = new UTF8Encoding(true);
      var preamble = enc.GetPreamble();
      if (preamble.Where((p, i) => p != bytes[i]).Any()) 
        throw new ArgumentException("Not utf8-BOM");
      return enc.GetString(bytes.Skip(preamble.Length).ToArray());
    }
