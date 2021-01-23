    credentialCache cache = new CredentialCache();
    cache.Add( new Uri(service.Url), // Web service URL
           "Negotiate",  // Kerberos or NTLM
           new NetworkCredential("username", "password", "domainname") );
    service.Credentials = cache;
