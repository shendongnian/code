    XDocument themes = XDocument.Load(HttpContext.Current.Server.MapPath("~/Models/Themes.xml"));
    string result = "";
    var childType = from t in themes.Descendants("theme")
                    where t.Attribute("name").Value.Equals(theme)
                    where t.FirstNode().Attribute("type").Value == parent
                    select new { value = t.Descendants().Attribute("type").Value };
        
    foreach (var t in childType) {
        result += t.value;
    }
    return result;
