    public List<string> GetAllHref(string htmlString)
    {
        List<string> hrefList = new List<string>();
        Regex rgxAttr = new Regex(@"data-react-props=""{(.*?)}""");
        Regex rgxValue = new Regex(@"""{(.*?)}""");
        var attrResult = rgxAttr.Matches(htmlString);
        List<string> attrValues = new List<string>();
        foreach (Match match in attrResult)
        {
            var val = rgxValue.Match(match.Value);
            attrValues.Add(val.Value.Replace("\"{", "{").Replace("}\"", "}"));
        }
        dynamic ob = null;
        foreach (var item in attrValues)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var dn = js.Deserialize<dynamic>(item) as Dictionary<string, object>;
            if (dn != null && dn.ContainsKey("areaCodes"))
                ob = dn["areaCodes"];
        }
        var s = ob as Array;
        foreach (Dictionary<string, object> item in s)
            hrefList.Add(item["href"].ToString());
        return hrefList;
    }
