    NetworkCredential networkCredential = new NetworkCredential("username", "password", "domainname");
    CredentialCache credentialCache = new CredentialCache();
    credentialCache.Add(new Uri(@"\\networkshare\"), "Basic", networkCredential);
    //Proceed with whatever file-io you need using the normal .NET file io. Example:
    string[] folders = System.IO.Directory.GetDirectories(@"\\networkshare\Users\Userimages");
