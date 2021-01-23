    MyVariableType MyVariable
    {
       get { return (MyVariable)(HttpContext.Current.Session["myvariable"] ?? SomeDefaultOrNullValue); }
       set { HttpContext.Current.Session["myvariable"] = value; }
    }
