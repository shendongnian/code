    public static Context GetInstance()
    {
        if (HttpContext.Current.Items["MyContext"] == null) 
        {
            HttpContext.Current.Items["MyContext"] = new Context();
        }
        return (Context)HttpContext.Current.Items["MyContext"];
    }
