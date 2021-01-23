    public List<string> GetMemberOf(DirectoryEntry de)
    {
      List<string> memberof = new List<string>();
      foreach (object oMember in de.Properties["memberOf"])
      {
        memberof.Add(oMember.ToString());
      }
      return memberof;
    }
    public DirectoryEntry GetObjectBySAM(string sam, DirectoryEntry root)
    {
      using (DirectorySearcher searcher = new DirectorySearcher(root, string.Format("(sAMAccountName={0})", sam)))
      {
        SearchResult sr = searcher.FindOne();
        if (!(sr == null)) return sr.GetDirectoryEntry();
        else
          return null;
      }
    }
