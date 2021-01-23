        string s = "<item><name> Foo > Bar </name></item>";
        s = Regex.Replace(s, @"<[^>]+?>", m => HttpUtility.HtmlEncode(m.Value)).Replace("<","ojlovecd").Replace(">","cdloveoj");
        s = HttpUtility.HtmlDecode(s).Replace("ojlovecd", "&gt;").Replace("cdloveoj", "&lt;");
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(s);
