    var bannerTop = htmlDoc.GetElementbyId("bannerTop");
    string oldStyle = bannerTop.Attributes["style"].Value;
    string newStyles = "";
    foreach (var entries in oldStyle.Split(';'))
    {
        var values = entries.Split(':');
        if (values[0].ToLower() == "bgcolor")
        {                                                                   
            values[1] = "#0000FF";
            newStyles += String.Join(':', values) + ";";
        }
        else
        {
            newStyles += entries + ";";
        }
                
    }
    bannerTop.Attributes["style"].Value = newStyles;
