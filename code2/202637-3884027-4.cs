    public static class AgentDescriptions: Dictionary<string, int>  
    { 
       public static int P1 { get { return GetId("P1"); } }
       public static int P2 { get { return GetId("P2"); } }
       public static int P3 { get { return GetId("P3"); } }
       public static int GetId(string agencyId)
       {
          if (!Contains(agencyId))
              Add(agencyId, GetIDFromDB(agencyID));
          return base[agencyId];
       }
