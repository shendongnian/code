    public static class AgentDescriptions: Dictionary<int, int>  
    { 
       private static int agencyId = GetAgencyId FromConfigFileOrSomewhere();
       public static readonly int P1 = GetIDFromDB(agencyID);  
       public static readonly int P2 = GetIdFromDB(agencyID);  
       public static int this[int agencyId]
       {
          get 
             {
                if (!Contains(agencyId))
                    Add(agencyId, GetIDFromDB(agencyID));
                return base[agencyId];
             }
       }
     // ...
