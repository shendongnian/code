    public static class AgentDescriptions  
    { 
       private static readonly Dictionary<int, int> dic
            = new Dictionary<int, int>();
       public static int GetId(int agencyId)
       {
           if (!dic.ContainsKey(agencyId))
                Adic.dd(agencyId, GetIDFromDB(agencyID));
           return dic[agencyId];
       }
     // ...
