	// Get and display all the title and Description
                XmlElement root = listXml.DocumentElement;
                XmlNodeList elemList = root.GetElementsByTagName("content");
                XmlNodeList elemList_title = root.GetElementsByTagName("d:Title");
                XmlNodeList elemList_desc = root.GetElementsByTagName("d:Description");
           
                for (int i = 0; i < elemList.Count; i++)
                {
                   
                    string title = elemList_title[i].InnerText;
                    string description = elemList_desc[i].InnerText;
			Console.WriteLine(title+description);
                  
                }
