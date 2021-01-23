    public static class AgentDescriptions: Dictionary<string, int>  
    { 
       public static int GetId(string agencyId)
       {
           if (!Contains(agencyId))
               Add(agencyId, GetIDFromDB(agencyID));
           return base[agencyId];
       }
     // ...
