           string personBirthday = string.Empty;
            string soapResult = @"<?xml version=""1.0"" encoding=""utf - 8"" ?><INDV> <PERSON> <BRTHDATES><BRTHDATE value = ""5/1/1963"" code = ""B"" /> </BRTHDATES></PERSON></INDV> ";
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(soapResult));
            XmlNodeList person = doc.GetElementsByTagName("BRTHDATES");
            if (person[0].ChildNodes.Count > 0)
            {
                foreach (XmlNode item in person[0].ChildNodes)
                {
                    if (item.Name.Trim().Equals("BRTHDATE"))
                    {
                        personBirthday = !string.IsNullOrEmpty(item.Attributes[0].Value) ? item.Attributes[0].Value.Trim() : string.Empty;
                    }
                }
            }
