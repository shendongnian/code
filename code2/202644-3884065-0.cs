    public class AgentDescriptions
    {
        static Dictionary<int,int> agentCache = new ...;
        public static int GetP1(int agentID)
        {
           if (!agentCache.ContainsKey(agentID))
              agentCache.Add(agentID, GetIdFromDB(agencyID));
    
           return agentCache[agentID];
        }
    
        ...
