    var doc = XDocument.Parse(System.Web.HttpUtility.HtmlDecode(response.Body));
    string evaluator = matchString[i].xpath.Substring(0, matchString[i].xpath.IndexOf("["));
    var fields = (IEnumerable)doc.XPathEvaluate(evaluator);
    var values = fields.Cast<XElement>()
                           .Select(x => new { 
                              key = x.Attribute("key").Value, 
                              value = x.Attribute("value").Value 
                           }).ToList();
