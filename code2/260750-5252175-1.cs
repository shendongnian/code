    public List<string> GetMemberOf(DirectoryEntry de)
    {
      List<string> memberof = new List<string>();
    
      foreach (object oMember in de.Properties["memberOf"])
      {
        memberof.Add(oMember.ToString());
      }
    
      return memberof;
    }
