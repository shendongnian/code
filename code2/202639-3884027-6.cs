    public static class AgentDescriptions 
    { 
       private static readonly Dictionary<string, int> dic
            = new Dictionary<string, int>();
       public static int GetId(string agencyId)
       {
           if (!dic.ContainsKey(agencyId))
               Adic.dd(agencyId, GetIDFromDB(agencyID));
           return dic[agencyId];
       }
     // ...
