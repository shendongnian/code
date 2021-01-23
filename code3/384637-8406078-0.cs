    public static string UsrId {
        get{
            var userId = HttpContext.Current.Session["usrid"];
            if (userId == null) { return ServiceVars.GuestId;}
            return userId .ToString();
        }
    }
