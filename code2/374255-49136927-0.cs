            bool attemptResult = false;
            string ldap = "LDAP:<Your A.D. specific connection string>";
            DirectoryEntry entry = new DirectoryEntry(ldap, username, password, AuthenticationTypes.Secure);
                      
            try
            {
                DirectorySearcher searcher = new DirectorySearcher(entry);
                searcher.Filter = "(&(objectClass=User)(sAMAccountName=" + username + "))";
                SearchResult one = searcher.FindOne();
                attemptResult = true;
                string properties = "";
                string userData = JsonConvert.SerializeObject(one.Properties);
                foreach (System.Collections.DictionaryEntry de in one.Properties) {
                    properties += (properties.Length > 0 ? ",\n" : "");
                    properties += "\"" + de.Key + "\": [";
                    ResultPropertyValueCollection vc = ((ResultPropertyValueCollection)de.Value);
                    foreach (var val in vc) {
                        properties += "{\"type\": \"" + val.GetType().Name + "\", \"value\"; \"" + val.ToString() + "\"}";
                    }
                    properties += "]";
                }
                properties = properties.Replace("}{", "},{");
                string displayName = one.Properties["displayname"][0].ToString();
                string givenName = one.Properties["givenname"][0].ToString();
                string lastname =  one.Properties["sn"][0].ToString();
            }
            catch (Exception e) {
                //log the error;
            }            
            return attemptResult;
