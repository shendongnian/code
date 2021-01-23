    public bool Authenticate(string userName, string passwd)
            {
                //Domain .
                string domain = "YOUR_DOMAIN_NAME";
                string domainAndUsername = domain + @"\" + userName;
                DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, passwd);
    
                try
                {
                    //Bind to the native AdsObject to force authentication.
                    object obj = entry.NativeObject;
    
                    DirectorySearcher search = new DirectorySearcher(entry);
    
                    search.Filter = "(SAMAccountName=" + userName + ")";
                    search.PropertiesToLoad.Add("cn");
                    SearchResult result = search.FindOne();
    
                    if (null == result)
                    {
                        return false;
                    }
    
                    //Update the new path to the user in the directory.
                    _path = result.Path;
                    _filterAttribute = (string)result.Properties["cn"][0];
                }
                catch (Exception ex)
                {
                     
                    PageLogger.AddToLogError("AUTH_ERROR", ex);
                    return false;
    
                }
    
                return true;
            }
    
            private  string GetGroups()
            {
                DirectorySearcher search = new DirectorySearcher(_path);
                search.Filter = "(cn=" + _filterAttribute + ")";
                search.PropertiesToLoad.Add("memberOf");
                StringBuilder groupNames = new StringBuilder();
    
                try
                {
                    SearchResult result = search.FindOne();
                    int propertyCount = result.Properties["memberOf"].Count;
                    string dn;
                    int equalsIndex, commaIndex;
    
                    for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
                    {
                        dn = (string)result.Properties["memberOf"][propertyCounter];
                        equalsIndex = dn.IndexOf("=", 1);
                        commaIndex = dn.IndexOf(",", 1);
                        if (-1 == equalsIndex)
                        {
                            return null;
                        }
                        groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
                        groupNames.Append("|");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error obtaining group names. " + ex.Message);
                }
                return groupNames.ToString();
            }
