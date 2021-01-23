    public string UserName {
        get {
            return (from u in context.Users
                    where u.UserID==session["UserID"]
                    select u.UserName).SingleOrDefault(); 
        }
    }
