    private object _lockObject = new object();
    public static List<Member> AllMembers
    {
        get
        {
            lock (_lockObject)
            {
                object result = HttpRuntime.Cache["Members"];
                if (result != null)
                {
                    return (List<Member>)result;
                }
                else
                {
                    GetAllMembers();
                    return (List<Member>)HttpRuntime.Cache["Members"];
                }
            }
        }
    }
