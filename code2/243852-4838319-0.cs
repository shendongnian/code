    public static class SessionObjects
    {
        public static Dictionary<DateTime, List<int>> MySessionStoredLists
        {
                get
                {
                        var session = HttpContext.Current.Session;
                        if (session == null) throw new InvalidOperationException();
                        var fromSession = (Dictionary<DateTime, List<int>>)session["MySessionStoredLists"];
                        if (fromSession == null)
                        {
                                fromSession = new Dictionary<DateTime, List<int>>();
                                MySessionStoredLists = fromSession;
                        }
                        return fromSession;
                }
                private set
                {
                    session["MySessionStoredLists"] = value;
                }
        }
    }
