    using (DirectoryEntry e = new DirectoryEntry("LDAP://server10/CN=users,DC=treyresearch,DC=net", 
                                             "treyresearch\\administrator", "P@$$W0rd", AuthenticationTypes.FastBind | AuthenticationTypes.Secure))
      {
        using (DirectorySearcher ds = new DirectorySearcher(e, "(&(objectCategory=inetorgperson)(logonCount=0))"))
        {
          ds.SearchScope = SearchScope.OneLevel;
          ds.PropertiesToLoad.Clear();
          ds.PropertiesToLoad.Add("logonCount");
          ds.PropertiesToLoad.Add("sAMAccountName");
          Stopwatch sw = new Stopwatch();
          sw.Start();
          int countPerson = 0;
          using (SearchResultCollection searchResultCol = ds.FindAll())
          {
            foreach (SearchResult sr in searchResultCol)
            {
              ResultPropertyValueCollection propCol = sr.Properties["logonCount"];
              if (propCol.Count > 0)
              {
                countPerson++;
                object cou = propCol[0];
              }
            }
            sw.Stop();
            Console.Out.WriteLine(sw.ElapsedMilliseconds);
            Console.Out.WriteLine(countPerson);
          }
        }
      }
