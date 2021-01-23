    public override string GetVaryByCustomString(HttpContext context, string arg)
    {
        if (arg == "login")
        {
            return User().Name;
        }
        return base.GetVaryByCustomString(context, arg);
    }
