    public static class AgentDescriptions
    {
        private static readonly Dictionary<string, int> dic
            = new Dictionary<string, int>();
        public static int P1 { get { return GetId("P1"); } }
        public static int P2 { get { return GetId("P2"); } }
        public static int P3 { get { return GetId("P3"); } }
        public static int GetId(string agencyId)
        {
            if (!dic.ContainsKey(agencyId))
                dic.Add(agencyId, 12);
            return dic[agencyId];
        } 
