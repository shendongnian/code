        try
        {
            string adServer = ConfigurationManager.AppSettings["Server"];
            string adDomain = ConfigurationManager.AppSettings["Domain"];
            string adUsername = ConfigurationManager.AppSettings["AdiminUsername"];
            string password = ConfigurationManager.AppSettings["Password"];
            string[] dc = adDomain.Split('.');
            string dcAdDomain = string.Empty;
            foreach (string item in dc)
            {
                if (dc[dc.Length - 1].Equals(item))
                    dcAdDomain = dcAdDomain + "DC=" + item;
                else
                    dcAdDomain = dcAdDomain + "DC=" + item + ",";
            }
            DirectoryEntry de = new DirectoryEntry("LDAP://" + adServer + "/CN=Users," + dcAdDomain, adUsername, password);
            DirectorySearcher ds = new DirectorySearcher(de);
            ds.SearchScope = SearchScope.Subtree;
            ds.Filter = "(&(objectClass=User)(sAMAccountName=" + username + "))";
            if (ds.FindOne() != null)
                return true;
        }
        catch (Exception ex)
        {
            ExLog(ex);
        }
        return false;
