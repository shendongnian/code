    public static class UserSession
    {
        public static int UserID
        {
             get { return Convert.ToInt32(Session["userID"]); }
             set { Session["userID"] = value; }
        }
    }
