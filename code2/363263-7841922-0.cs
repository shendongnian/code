    public static Dictionary<string, object> OpenChannels
    {
        get
        {
            if (Cache["OpenChannels"] == null)
            {
                Cache["OpenChannels"] = new Dictionary<string, object>();
            }
            
            return (Dictionary<string, object>)Cache["OpenChannels"];
        }
        set
        {
            Cache["OpenChannels"] = value;
        }
    }
