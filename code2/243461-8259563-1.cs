    private static readonly object padlock = new object();
    private static Dictionary<string,SessionData> sessions = new Dictionary<string,SessionData>();
    public static Dictionary<string, SessionData> Sessions
    {
        get { lock (padlock) { return sessions; } }
    }
    public struct SessionData
    {
        public string Name { get; set; }
        public int AccountId { get; set; }
        public string CurrentLocation { get; set; }
    }
    protected void Session_Start(object sender, EventArgs e)
    {
        Sessions.Add(Session.SessionID, new SessionData());
    }
    protected void Session_End(object sender, EventArgs e)
    {
        Sessions.Remove(Session.SessionID);
    }
    public static void SetSessionData(string sessionId, int accountId, string name, string currentLoc)
    {
        Sessions.Remove(sessionId);
        Sessions.Add(sessionId, new SessionData { AccountId = accountId, CurrentLocation = currentLoc, Name = name });
    }
    public static void SetCurrentLocation(string sessionId, string currentLoc)
    {
        SessionData currentData = Sessions[sessionId];
        Sessions.Remove(sessionId);
        Sessions.Add(sessionId, new SessionData { AccountId = currentData.AccountId, CurrentLocation = currentLoc, Name = currentData.Name });
    }
