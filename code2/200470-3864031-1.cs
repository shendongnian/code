     string userName = "TargetUserName";
    
            using (DirectorySearcher searcher = new DirectorySearcher("GC://yourdomain.com"))
            {
                searcher.Filter = string.Format("(&(objectClass=user)(sAMAccountName={0}))", userName);
    
                using (SearchResultCollection results = searcher.FindAll())
                {
                    Debug.WriteLine("Found User");
    
                }
            }
  
