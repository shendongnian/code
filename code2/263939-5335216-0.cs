    DirectoryEntry dir = new DirectoryEntry();
        dir.Path = "LDAP://YourActiveDirServername ";        
        DirectorySearcher sea = new DirectorySearcher(dir);
        sea.Filter = "(sAMAccountName=Uname)";
        SearchResult seares = sea.FindOne();      
        StringBuilder str = new StringBuilder();
        System.DirectoryServices.ResultPropertyCollection prop = seares.Properties;
        ICollection coll = prop.PropertyNames;
        IEnumerator enu = coll.GetEnumerator(); 
            while (enu.MoveNext())
            {
                str.Append(enu.Current + " = " + seares.Properties[enu.Current.ToString()][0] + "\n");
            }  
