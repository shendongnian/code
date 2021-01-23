     public static bool IsAccountMemberOfGroup(string account, string group)
     {
        bool found = false;
        using (DirectoryEntry entry = new DirectoryEntry(account))
        {
            entry.RefreshCache(new string[] { "memberOf" });
            foreach (string memberOf in entry.Properties["memberOf"])
            {
               if (string.Compare(memberOf, group, true) == 0)
               {
                  found = true;
                  break;
               }
            }
        }
        return found;
     }
