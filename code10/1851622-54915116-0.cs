            string xBal = "200";
            string path = "D:\\xml.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList NodeList = xmlDoc.GetElementsByTagName("Game");
            foreach (XmlNode item in NodeList)
            {
                if (item.Attributes[0].InnerText.Equals("Tennis"))
                {
                    XmlNode balance = item.SelectSingleNode("balance");
                    balance.InnerText = xBal;
                }
            }
            xmlDoc.Save(path);
