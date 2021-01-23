    class Dummy
    {
        public string foo { get; set; }
    }
    static void Main(string[] args)
    {
        string s = @"blah \u003c blah \u00252 blah";
        string json = @"{""foo"":""" + s + @"""}";
        string unencoded = new JavaScriptSerializer().Deserialize<Dummy>(json).foo;
    }
