        {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(pathToSettingsFile);
        XmlNodeList list = xmldoc.GetElementsByTagName("Setting");
        foreach (XmlNode node in list)
        {
             string keystring = node.Attributes["Name"].InnerText;
             string valuestring =  node.FirstChild.InnerText;
             settingValues.Add(keystring,valuestring);
        }
        var t = File.OpenText(constantsfilename);
        string text;
        using (t)
        {
            text = t.ReadToEnd();
        }
        string sample = "{code:Settings|";
        char endsign = '}';
        while (text.Contains(sample))
        {
            int startindex = text.IndexOf(sample);
            int endindex = text.IndexOf(endsign, startindex);
            int variableIndex = startindex + sample.Length;
            string variable = text.Substring(variableIndex, endindex - variableIndex);
            text = text.Replace(sample + variable + endsign, newVal(variable));
        }
                           
        var w = new StreamWriter(constantsfilename);
        using (w)
        {
            w.Write(text);
            w.Flush();
        }
        }
        public static string newVal(string variable)
        {
            if (settingValues.ContainsKey(variable))
                return settingValues[variable];
            else
            {
                return "";
            }
        }
