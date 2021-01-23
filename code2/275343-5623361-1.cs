    static void Main(string[] args)
    {
      /* Retreiving a principal context
       */
      PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, "WM2008R2ENT", "dc=dom,dc=fr", "TheUser", "ThePassword");
    
      /* Discribe the group You are looking for as a principal
       */
      GroupPrincipal gpPrincipal = new GroupPrincipal(domainContext);
      gpPrincipal.Name = "abc-*";
    
      /* Bind a searcher
       */
      PrincipalSearcher searcher = new PrincipalSearcher();
      searcher.QueryFilter = gpPrincipal;
    
      PrincipalSearchResult<Principal> hRes = searcher.FindAll();
    
      /* Read The result
       */
      foreach (GroupPrincipal grp in hRes)
      {
        Console.WriteLine(grp.Name);
        // You are looking for "grp.Members"
      }
    
      Console.ReadLine();
    }
