    public static T FromJson<T>(this string s)
    {
        var ser = new System.Web.Script.Serialization.JavaScriptSerializer.JavaScriptSerializer();
        return ser.Deserialize<T>(s);
    }
