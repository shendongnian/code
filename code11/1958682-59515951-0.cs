    public class UserSession
    {
        public int UserID { get; set; }
        public string User { get; set; }
        public string DisplayName { get; set; }
        public UserSession(int id, string user, string displayName) 
        {
             UserID = id;
             User = user;
             DisplayName = displayName;
        }
    }
