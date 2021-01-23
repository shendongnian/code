    //this executes very long time, 50s and more, but only once.
    private SomeObj SessionSomeObj { 
      get 
      { 
        var ret = (SomeObj)Session["SomeObjStore"] ?? SomeClass.GetSomeObj();
        SessionSomeObj = ret;
        return ret; 
      }
      set { Session["SomeObjStore"] = value; }
    }
    [WebMethod(EnableSession = true)]
    public string Method1()
    {
        return SessionSomeObj.Method1(); //this exetus in a moment 
    }
    [WebMethod(EnableSession = true)]
    public string Method2()
    {
        return SessionSomeObj.Method2(); //this exetus in a moment 
    }
