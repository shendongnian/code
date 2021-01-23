    public User CurrentUser {
        get { 
            return Session["CurrentUser"] != null ?
                (User) Session["CurrentUser"] :
                null;
        }
        set { Session["CurrentUser"] = value; }
    }
