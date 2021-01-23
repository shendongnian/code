    public override string GetVaryByCustomString(
        HttpContext context,
        string arg)
    {
        if (arg == "Language")
        {
             return Session["lang"].ToString();
        }
        else
        {
            return base.GetVaryByCustomString(context, arg);
        }
    }
