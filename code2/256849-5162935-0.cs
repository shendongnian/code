        System.Net.FtpWebRequest f = System.Net.FtpWebRequest.Create(new Uri("ftp://somewhere.com")) as System.Net.FtpWebRequest;
        if (f != null)
        {
            f.Credentials = new System.Net.NetworkCredential("username", "password", "domain");
            f.Credentials = new System.Net.NetworkCredential("username", "password");
            f.Credentials = new System.Net.NetworkCredential(System.Security.Principal.WindowsIdentity.GetCurrent().Name, "password");
        }
