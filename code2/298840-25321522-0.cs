                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Name"));
                dt.Columns.Add(new DataColumn("POCode"));
                dt.Columns.Add(new DataColumn("Active"));
                DataRow dtrow;
                DirectoryEntry myLdapConnection = createDirectoryEntry();
                List<Users> listAlluers = new List<Users>();
            
                DirectorySearcher search = new DirectorySearcher(myLdapConnection);
                SearchResult result;
                SearchResultCollection resultCol = search.FindAll();
                //search.PropertiesToLoad.Add("cn");//user name
                //search.PropertiesToLoad.Add("title"); //design
                if (resultCol != null)
                {
                    for (int counter = 0; counter < resultCol.Count; counter++)
                    {
                        string UserNameEmailString = string.Empty;
                        result = resultCol[counter];
                        if (result.Properties.Contains("cn") && result.Properties.Contains("title"))
                        {
                            dtrow = dt.NewRow();
                            dtrow[0] = (String)result.Properties["cn"][0];
                            dtrow[1] = (String)result.Properties[BusinessLayer.UserConfig.UniqueField][0];
                            dtrow[2] = (String)result.Properties["useraccountcontrol"][0];
                            dt.Rows.Add(dtrow);
                        }
                    }
                }  
            
            return dt;
        }
        static DirectoryEntry createDirectoryEntry()
        {
           
            String Path = "LDAP://your.server.Ip";
            DirectoryEntry ldapConnection = new DirectoryEntry(Path, "username", "password");
       
            return ldapConnection;
        }
