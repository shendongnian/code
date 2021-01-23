    [WebMethod]
    public string MyMethod( )
    {
       var parameter = new JavaScriptSerializer().Deserialize<SomeStruct>(HttpContext.Current.Request["parameter"]);
    }
