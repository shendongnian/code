    XmlDocument doc = new XmlDocument();
        doc.Load(@"sample.xml");
        XmlNodeList builderNodes =  doc.GetElementsByTagName("builderemail");
        XmlNodeList mangerNodes = doc.GetElementsByTagName("manageremail");
        List<string> builderMails = new List<string>();
        foreach (XmlNode node in builderNodes[0].ChildNodes)
        {
            builderMails.Add(node.Attributes["value"].Value);
        }
        List<string> mangerMails = new List<string>();
        foreach (XmlNode node in mangerNodes[0].ChildNodes)
        {
            mangerMails.Add(node.Attributes["value"].Value);
        }
       
         comboBox1.DataSource = builderMails;
            comboBox2.DataSource = mangerMails;
   
