    DirectoryEntry di = new DirectoryEntry("IIS://prodweb1/W3SVC/1");
    PropertyValueCollection sslCertHashProperty = di.Properties["SSLCertHash"];
    if (sslCertHashProperty.Count > 0)
    {
      Console.WriteLine("Site has associated SSL Certificate.");
    }
    PropertyValueCollection secureBindingsProperty = di.Properties["SecureBindings"];
    if (secureBindingsProperty.Count > 0)
    {
      Console.WriteLine("Site has at least one SSL (https) binding.");
    }
    PropertyValueCollection serverBindingsProperty = di.Properties["ServerBindings"];
    if (serverBindingsProperty.Count > 0)
    {
      Console.WriteLine("Site has at least one non-SSL (http) binding.");
    }
