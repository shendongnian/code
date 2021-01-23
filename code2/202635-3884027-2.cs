    public static class AgentDescriptions: Dictionary<int, int>  
    { 
       public static int GetId(int agencyId)
       {
           if (!Contains(agencyId))
                Add(agencyId, GetIDFromDB(agencyID));
           return base[agencyId];
       }
     // ...
