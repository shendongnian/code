            var doc = new XmlDocument();
            doc.LoadXml("<root>\r\n  <context-param>\r\n    <param-name>Religion Name</param-name>\r\n    <param-value>Roman Catholic</param-value>\r\n  </context-param>\r\n  <context-param>\r\n    <param-name>Name</param-name>\r\n    <param-value>James Smith</param-value>\r\n  </context-param>\r\n</root>");
            var nameList = doc.GetElementsByTagName("param-name");
            var valueList = doc.GetElementsByTagName("param-value");
            for (int i = 0; i < nameList.Count; i++)
            {
                if (nameList[i].InnerXml.Equals("Religion Name"))
                {
                    //get your value
                    var value= valueList[i].InnerXml;
                }
                
            }
