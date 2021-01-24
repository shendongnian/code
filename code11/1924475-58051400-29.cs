    public string Password
    {
      get
      {
        lock ( locker )
        {
          if ( _Password.IsNullOrEmpty() ) return _Password;
          var buf = Encoding.Default.GetBytes(_Password);
          ProtectedMemory.Unprotect(buf, MemoryProtectionScope.SameProcess);
          return Encoding.Default.GetString(Decrypt(buf, _SecureKey.ToString()));
        }
      }
      set
      {
        lock ( locker )
        {
          if ( !MemorizePassword ) return;
          CreateSecureKey();
          if ( value.IsNullOrEmpty() ) _Password = value;
          else
          {
            var buf = Encrypt(Encoding.Default.GetBytes(value), _SecureKey.ToString());
            ProtectedMemory.Protect(buf, MemoryProtectionScope.SameProcess);
            _Password = Encoding.Default.GetString(buf);
          }
        }
      }
    }
    private void CreateSecureKey()
    {
      _SecureKey = new SecureString();
      foreach ( char c in Convert.ToBase64String(CreateCryptoKey(64)) )
        _SecureKey.AppendChar(c);
      _SecureKey.MakeReadOnly();
    }
    static public byte[] CreateCryptoKey(int length)
    {
      if ( length < 1 ) length = 1;
      byte[] key = new byte[length];
      new RNGCryptoServiceProvider().GetBytes(key);
      return key;
    }
