    MyType MyObject
    {
        get
        {
            MyType myObject = Session["MySessionKey"] as MyType
            if (myObject == null)
            {
                myObject = ... get data from a backing store
                Session["MySessionKey"] = myObject;  
            }
            return myObject;
        }
        set
        {
            Session["MySessionKey"] = value;
            ... and persist it to backing store if appropriate
        }
    }
