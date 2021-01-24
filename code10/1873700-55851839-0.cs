    public List<AreaCode> GetAllAreaCodes(string htmlString)
    {
        List<AreaCode> areraCodes = new List<AreaCode>();
        Regex rgxAttr = new Regex(@"data-react-props=""{(.*?)}""");
        Regex rgxValue = new Regex(@"""{(.*?)}""");
        var attrResult = rgxAttr.Matches(htmlString);
        List<string> attrValues = new List<string>();
        foreach (Match match in attrResult)
        {
            var val = rgxValue.Match(match.Value);
            attrValues.Add(val.Value.Replace("\"{", "{").Replace("}\"", "}"));
        }
        foreach (var item in attrValues)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
                
            var dn = js.Deserialize<dynamic>(item) as Dictionary<string, object>;
            if (dn != null && dn.ContainsKey("areaCodes"))
            { 
                var abc = item.Remove(item.Length - 1, 1).Remove(0, 1).Replace(@"""areaCodes"":", "");
                areraCodes = js.Deserialize<List<AreaCode>>(abc);
            }
        }
        return areraCodes;
    }
    public class AreaCode
    {
        public string phone_prefix { get; set; }
        public string location { get; set; }
        public string href { get; set; }
        public string[] details { get; set; }
    }
