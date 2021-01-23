    public string UserName {
        get {
            set from u in context.Users
            where u.UserID==session["UserID"]
            select u.UserName; 
        }
    }
