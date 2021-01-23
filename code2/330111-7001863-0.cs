    string ldapPath = "LDAP://" + distinguishedName;
    
    using(DirectoryEntry de = new DirectoryEntry(ldapPath))
    {
       // check to see if we have "userAccountControl" in the **properties** of de
       if(de.Properties.Contains("userAccountControl")
       {
          int m_Val  = (int)de.Properties["userAccountControl"][0].Value ;
          de.Properties["userAccountControl"].Value = m_Val | 0x0001;
   
          de.CommitChanges();
       }
    }
