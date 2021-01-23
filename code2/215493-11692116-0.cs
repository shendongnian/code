    private string BytesToString(byte[] Bytes)
    {
      MemoryStream MS = new MemoryStream(Bytes);
      StreamReader SR = new StreamReader(MS);
      string S = SR.ReadToEnd();
      SR.Close();
      return S;
    }
    private string ToUnicode(string S)
    {
      return BytesToString(new UnicodeEncoding().GetBytes(S));
    }
