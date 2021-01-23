    // System.Data.Entity.Internal.CodeFirstCachedMetadataWorkspace
    private static SHA256 GetSha256HashAlgorithm()
    {
      SHA256 result;
      try
      {
        result = new SHA256CryptoServiceProvider();
      }
      catch (PlatformNotSupportedException)
      {
        result = new SHA256Managed();
      }
      return result;
    }
