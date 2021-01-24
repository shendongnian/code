            public bool Post(string user, string pass, string domain)
        {
            DirectoryEntry objDirEntry = new DirectoryEntry("LDAP://" + domain, user, pass);
            try
            {
                DirectorySearcher search = new DirectorySearcher(objDirEntry);
                SearchResult result = search.FindOne();
                if (result == null)
                    return false;
                string[] name = ConfigurationManager.AppSettings["name"].Split(',');
                if (name.Any(x => x.ToLower() == user.ToLower()))
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
