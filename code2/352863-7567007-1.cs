        string xml = Application.StartupPath + "\\OrgName.xml";
        XmlDocument xmlDoc = new XmlDocument();
        if (System.IO.File.Exists(xml))
        {
           xmlDoc.Load(xml);
           XmlElement root = xmlDoc.DocumentElement;
           string orgName = root.SelectSingleNode(@"descendant::Org[@ID='1']/OrgName").InnerText;
           MessageBox.Show(orgName);
        }
 
