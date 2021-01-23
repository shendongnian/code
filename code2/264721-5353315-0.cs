    public bool UserExistsActiveDir()
        {
            try
            {
                const int ADS_UF_ACCOUNTDISABLE = 0x00000002;
                DirectoryEntry de = new DirectoryEntry();
                de.Path = "LDAP://domainname;
                DirectorySearcher objADSearcher = new DirectorySearcher(de);
                de.AuthenticationType = AuthenticationTypes.Secure;
                objADSearcher.SearchRoot = de;
                objADSearcher.Filter = "(SAMAccountName=" + txtUserName.Text + ")";
                SearchResult results = objADSearcher.FindOne();
                if (results.ToString() != "")
                {
                    int flags = Convert.ToInt32(results.Properties["userAccountControl"][0].ToString());
                    //results.Properties["userAccountControl"][0].ToString().Equals("514");
                    if (Convert.ToBoolean(flags & ADS_UF_ACCOUNTDISABLE))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
    // <-here
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
                return false;
            }          
        }
