            using (SqlDataReader dsReader = cmd.ExecuteReader())
            {
                XElement result = new XElement("root");
                while (dsReader.Read())
                {
                    // Read source
                    XDocument srcDoc = XDocument.Parse(dsReader["x"].ToString());
                    // Construct result element
                    foreach (XElement baseElement in srcDoc.Descendants("root").Elements())
                        if (result.Element(baseElement.Name) == null)   // skip already added nodes
                            result.Add(new XElement(baseElement.Name, baseElement.Value));
                }
                // Construct result string from sub-elements (to avoid "<root>..</root>" in output)
                string str = result.Elements().Aggregate("", (current, element) => current + element.ToString());
                // send the result
                SqlContext.Pipe.Send("start:" + str);
            }
