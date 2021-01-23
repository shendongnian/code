    private static string GetCleanedFileName(string s)
    {
      StringBuilder sb = new StringBuilder();
      foreach(byte b in Encoding.UTF8.GetBytes(s))
      {
        if(b < 128 && b != 0x25)// ascii and not %
          sb.Append((char)b);
        else
          sb.Append('%').Append(b.ToString("X2"));
      }
      return sb.ToString();
    }
