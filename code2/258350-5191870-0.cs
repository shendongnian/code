    private ICredentials BuildCredentials(string siteurl, string username, string password, string authtype) {
        NetworkCredential cred;
        if (username.Contains(@"\")) {
            string domain = username.Substring(0, username.IndexOf(@"\"));
            username = username.Substring(username.IndexOf(@"\") + 1);
            cred = new System.Net.NetworkCredential(username, password, domain);
        } else {
            cred = new System.Net.NetworkCredential(username, password);
        }
        CredentialCache cache = new CredentialCache();
        if (authtype.Contains(":")) {
            authtype = authtype.Substring(authtype.IndexOf(":") + 1); //remove the TMG: prefix
        }
        cache.Add(new Uri(siteurl), authtype, cred);
        return cache;
    }
