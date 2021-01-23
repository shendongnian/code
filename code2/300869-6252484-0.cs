    [WebMethod]
    public static string Login(string username, string password)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        dynamic obj = new ExpandoObject();
        obj.error = "No IDs";
        string str = js.Serialize(obj);
        return str;
    }
