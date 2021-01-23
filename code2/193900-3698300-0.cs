    public static string GetDomainTypeName(this Uri uri)
    {
      if (!uri.HostNameType.Equals(UriHostNameType.Dns) || uri.IsLoopback)
         return string.Empty; // or throw an exception
      return uri.Host.Split('.').Last();
    }
