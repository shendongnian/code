    [WebMethod, ScriptMethod]
    public IEnumerable<YourNode> GetChildNodes(string nodeText, string nodeValue, int param2)
    {
       //call your DAL with any parameter you passed in from above
       IEnumerable<YourNode> nodes = ...
       return nodes;
    }
