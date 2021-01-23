    /* Retreiving a principal context
     */
    PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, "WM2008R2ENT:389", "dc=dom,dc=fr", "jpb", "PWD");
    /* Look for all the groups from the root
     */
    GroupPrincipal allGroups = new GroupPrincipal(domainContext);
    allGroups.Name = "*";
    
    
    /* Bind a searcher
     */
    PrincipalSearcher searcher = new PrincipalSearcher();
    searcher.QueryFilter = allGroups;
    PrincipalSearchResult<Principal> hRes = searcher.FindAll();
    
    /* Read The result
     */
    List<DirectoryEntry> listContainerWithGroups = new List<DirectoryEntry>();
    foreach (GroupPrincipal grp in hRes)
    {
      DirectoryEntry deGrp = grp.GetUnderlyingObject() as DirectoryEntry;
      if (deGrp != null)
        listContainerWithGroups.Add(deGrp.Parent);
    }
    
    /* Get Unique Entries
     */
    var listContainerWithGroupsUnique = from o in listContainerWithGroups
                                        group o by o.Properties["distinguishedName"].Value into dePackets
                                        select dePackets.First();
    foreach (DirectoryEntry deTmp in listContainerWithGroupsUnique)
    {
      Console.WriteLine(deTmp.Properties["distinguishedName"].Value);
    }
