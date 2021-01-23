           // NetworkCredential stores authentication to a single internet resource
           // supplies credentials in password-based authentication schemes such as basic, digest, NTLM, and Kerberos. 
           NetworkCredential networkCredential = new NetworkCredential("username", "password");
    
            WebRequest webRequest = HttpWebRequest.Create("www.foobar.com");
            webRequest.Credentials = networkCredential;
    
            // to use the same credential for multiple internet resources...
            CredentialCache credentialCache = new CredentialCache();
            credentialCache.Add(new Uri("www.foobar.com"), "Basic", networkCredential);
            credentialCache.Add(new Uri("www.example.com"), "Digest", networkCredential);
    
            // now based on the uri and the authetication, GetCredential method would return the 
            // appropriate credentials
            webRequest.Credentials = credentialCache;
