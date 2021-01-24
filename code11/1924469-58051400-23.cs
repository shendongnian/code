    using System;
    using System.Security;
    using System.Security.Cryptography;
    using System.Text;
    using ( StreamWriter writer = new StreamWriter(filename) )
    {
      string password = AskPassword();
      writer.Write(Encrypt(Content, password));
    }
    using ( StreamReader reader = new StreamReader(filename) )
    {
      string password = AskPassword();
      string content = Decrypt(reader.ReadToEnd(), password);
    }
    static public byte[] Encrypt(byte[] data, string password)
    {
      return Encrypt(data, password, DefaultCryptoSalt);
    }
    static public byte[] Decrypt(byte[] data, string password)
    {
      return Decrypt(data, password, DefaultCryptoSalt);
    }
    static public string Encrypt(string str, string password, byte[] salt)
    {
      if ( str.IsNullOrEmpty() ) return str;
      PasswordDeriveBytes p = new PasswordDeriveBytes(password, salt);
      var s = Encrypt(Encoding.Default.GetBytes(str), p.GetBytes(32), p.GetBytes(16));
      return Convert.ToBase64String(s);
    }
    static public string Decrypt(string str, string password, byte[] salt)
    {
      if ( str.IsNullOrEmpty() ) return str;
      PasswordDeriveBytes p = new PasswordDeriveBytes(password, salt);
      var s = Decrypt(Convert.FromBase64String(str), p.GetBytes(32), p.GetBytes(16));
      return Encoding.Default.GetString(s);
    }
    static public byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
    {
      if ( data == null ) return data;
      using ( MemoryStream m = new MemoryStream() )
      {
        var r = Rijndael.Create().CreateEncryptor(key, iv);
        using ( CryptoStream c = new CryptoStream(m, r, CryptoStreamMode.Write) )
          c.Write(data, 0, data.Length);
        return m.ToArray();
      }
    }
    static public byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
    {
      if ( data == null ) return data;
      using ( MemoryStream m = new MemoryStream() )
      {
        var r = Rijndael.Create().CreateDecryptor(key, iv);
        using ( CryptoStream c = new CryptoStream(m, r, CryptoStreamMode.Write) )
          c.Write(data, 0, data.Length);
        return m.ToArray();
      }
    }
    static public byte[] CreateCryptoKey(int length)
    {
      if ( length < 1 ) length = 1;
      byte[] key = new byte[length];
      new RNGCryptoServiceProvider().GetBytes(key);
      return key;
    }
