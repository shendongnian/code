        XDocument doc = XDocument.Load("wc.config");
        foreach (XElement variableElement in doc.Descendants("variable"))
        {
            if (variableElement.Attribute("name").Value == "A")
            {
                variableElement.Attribute("value").Value = "";
            }
            else if (variableElement.Attribute("name").Value == "B")
            {
                variableElement.Attribute("value").Value = "999";
            }
        }
