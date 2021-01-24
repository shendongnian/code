    var match = new Regex("^(.*)\\[@key=\"(.*?)\".*@value=\"(.*?)\"]").Match(matchString[i].xpath);
    try
    {
        string evaluator = match.Groups[1].Value;    // /whitelist/locations/location/var-fields/var-field
        string target_key = match.Groups[2].Value;   // whitelist-entry
        string target_value = match.Groups[3].Value; // 8.0440147AA44A80
        var doc = XDocument.Parse(System.Web.HttpUtility.HtmlDecode(response.Body));
        var fields = (IEnumerable)doc.XPathEvaluate(evaluator);
        var values = fields.Cast<XElement>()
                               .Select(x => new {
                                   key = x.Attribute("key").Value,
                                   value = x.Attribute("value").Value
                               }).ToList();
        bool found = false;
        foreach (var val in values)
        {
            if (val.key == target_key && val.value == target_value)
            {
                found = true;
            }
        }
        if(found)
        {
            Report.Success("Content " + matchString[i].xpath + "is in reponse");
        }
        else
        {
            Report.Failure("Content " + matchString[i].xpath + "is not in reponse");
        }
    }
    catch
    {
        //Invalid xPath format
    }
