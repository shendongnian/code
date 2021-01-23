    public string SessionMagic(object input)
    {
         Session["egSession"] = input;
         return Session["egSession"].ToString();
    }
