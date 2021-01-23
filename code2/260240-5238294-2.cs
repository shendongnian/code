    protected MyClass Copy
    {
       get { return Session["MyClass"] as MyClass; }
       set { Session["MyClass"] = value; }
    }
