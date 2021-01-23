    [WebMethod(EnableSession = true)]
    public string ReadUserAdditional()
    {
        return GetUserInfo(new [] 
        {
            new FieldInfo {Name = "Image", u => u.Image},
            new FieldInfo {Name = "Biography", u => u.Biography} 
        });
    }
    private string GetUserInfo(FieldInfo[] infos) 
    {
        EUser user = (EUser)Session["user"];
        var dict = new Dictionary<string, object>{ { "result", true } };
        foreach(var info in infos) 
        {
            dictionary.Add(info.Name, info.Accessor(user));
        }
        return new JavaScriptSerializer().Serialize(dict );
    }
    public class FieldInfo 
    {
        public Func<EUser, object> Accessor { get; set; }
        public string Name { get; set;}
    }
