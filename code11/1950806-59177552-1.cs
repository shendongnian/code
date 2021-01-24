            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList itemNodes = xmlDoc.SelectNodes("//auth_token");
            foreach(XmlNode itemNode in itemNodes)
            {
                if((itemNode != null)
                    Console.WriteLine(itemNode.InnerText);
            }
