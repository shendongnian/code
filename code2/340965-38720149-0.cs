    System.Net.Configuration.SmtpSection section = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as System.Net.Configuration.SmtpSection;
    // set up SMTP client
    SmtpClient smtp = new SmtpClient();
    System.Net.CredentialCache myCache = new System.Net.CredentialCache();
    NetworkCredential myCred = new NetworkCredential(section.Network.UserName, section.Network.Password);
    string host = section.Network.Host;
    int port = section.Network.Port;
    // do this because NTLM doesn't work in all environments....
    if (myCred != null)
    {
        myCache.Add(host, port, "Digest", myCred);
        myCache.Add(host, port, "Basic", myCred);
        myCache.Add(host, port, "Digest-MD5", myCred);
        myCache.Add(host, port, "Digest MD5", myCred);
        myCache.Add(host, port, "Plain", myCred);
        myCache.Add(host, port, "Cram-MD5", myCred);
        myCache.Add(host, port, "Cram MD5", myCred);
        myCache.Add(host, port, "Login", myCred);
    
        //myCache.Add(host, port, "NTLM", myCred);
    }
    smtp.Credentials = myCache;
    smtp.UseDefaultCredentials = false;
    //smtp.EnableSsl = true;
