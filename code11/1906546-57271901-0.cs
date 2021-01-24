    public List<Person> FindPersonDetails(Person objPerson)
            {
                string lname = string.Empty, fname = string.Empty, mname = string.Empty, MSID = string.Empty;
                fname = objPerson.FirstName;
                lname = objPerson.LastName;
                mname = objPerson.MiddleName;
                MSID = objPerson.MSID;
                DataTable dt = new DataTable();
                dt.Columns.Add("DisplayName", typeof(string));
                dt.Columns.Add("GivenName", typeof(string));
                dt.Columns.Add("SurName", typeof(string));
                dt.Columns.Add("MSID", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("employeeid", typeof(string));
    
                //DirectoryEntry _objDirectoryEntry;
                DirectorySearcher searcher = new DirectorySearcher();
                if (lname != null && lname != "")
                {
                    if (mname != null && mname != "")
                        searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(givenName={0}*)(DisplayName={1}*)(middlename={2}*))", fname, lname, mname);
                    else
                        searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(givenName={0}*)(DisplayName={1}*))", fname, lname);
                }
                else if (MSID != null && MSID != "")
                {
                    searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(cn={0}))", MSID);
                }
                else
                {
                    if (mname != null && mname != "")
                        searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(givenName={0}*)(middlename={1}*))", fname, mname);
                    else
                        searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(givenName={0}*))", fname);
                }
                SearchResultCollection allResults;
                //searcher.SizeLimit = 100;
                searcher.Asynchronous = true;
                //searcher.ClientTimeout = TimeSpan.FromSeconds(7);
                allResults = searcher.FindAll();
                try
                {
                    if (allResults.Count >= 0)
                    {
                        for (int i = 0; i < allResults.Count; i++)
                        {
                            DirectoryEntry deMembershipUser = allResults[i].GetDirectoryEntry();
                            deMembershipUser.RefreshCache();
                            dt.Rows.Add(
                                (string)deMembershipUser.Properties["displayname"].Value ?? "Not Available",
                                (string)deMembershipUser.Properties["givenName"].Value ?? "Not Available",
                                (string)deMembershipUser.Properties["sn"].Value ?? "Not Available",
                                (string)deMembershipUser.Properties["cn"].Value ?? "Not Available",
                                (string)deMembershipUser.Properties["mail"].Value ?? "Not Available",
                                (string)deMembershipUser.Properties["employeeid"].Value ?? "Not Available"
                            );
                        }
                    }
                }
                catch ()
                {
    
                }
                dt.DefaultView.Sort = "DisplayName ASC";
                dt = dt.DefaultView.ToTable();
                List<Person> objPersonList = new List<Person>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Person obj = new Person();
    
                        obj.DisplayName = dr["displayname"].ToString();
                        //obj.GivenName = dr["givenName"].ToString();
                        //obj.SurName = dr["SurName"].ToString();
                        obj.Email = dr["Email"].ToString();
                        obj.MSID = dr["MSID"].ToString();
                        //obj.employeeid = dr["employeeid"].ToString();
                        objPersonList.Add(obj);
                    }
                }
    
                return objPersonList;
            }
      public class Person
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string MSID { get; set; }
            public string DisplayName { get; set; } 
            public string Email { get; set; }
            //public string employeeid { get; set; } 
        }
