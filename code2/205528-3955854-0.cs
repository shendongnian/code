    public override string GetVaryByCustomString(HttpContext context, string custom)
    {
        if (custom == "LoggedInUser")
        {
            if (UserIsLoggedIn())
            {
                return "LoggedInUser:" + GetUserNameOrSomeOtherUniquePerUserString();
            }
            else
            {
                return "LoggedInUser:NONE";
            }
        }
        return base.GetVaryByCustomString(context, custom);
    }
