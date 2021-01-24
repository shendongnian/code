    public static List<UserCall> UserCalls
    {
        get
        {
            lock (_locker)
            {
                if (userCalls == null)
                {
                    userCalls = new List<UserCall>();
                }
                return userCalls;
            }
        }
        set
        {
            lock (_locker)
            { 
                userCalls = value;
            }
        }
    }
    static object _locker = new object();
