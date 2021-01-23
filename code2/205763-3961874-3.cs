    private static object _allMembersLock = new object();
    public static List<Member> AllMembers
    {
        get
        {
            List<Member> members = (List<Member>)HttpRuntime.Cache["Members"];
            if (members == null)
                lock (_allMembersLock)
                {
                    members = (List<Member>)HttpRuntime.Cache["Members"];
                    if (members == null)
                    {
                        members = GetAllMembers();
                        HttpRuntime.Cache["Members"] = members;
                    }
                }
            }
            return members;
        }
    }
