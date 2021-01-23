    class AgentDescriptions 
    {
        AgentDescriptions()
        {
            P1 = GetIDFromDB(agencyID);
            P2 = GetIdFromDB(agencyID);
        }
        static public AgentDescriptions Instance 
        {
            get 
            {
                if (_instance==null)
                {
                    _instance=new AgentDescriptions();
                }
                return _instance;
            }
        }
        static private _instance;
    }
