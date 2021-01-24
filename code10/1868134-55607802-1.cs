                    StringBuilder result = new StringBuilder();
                    foreach (XElement level1Element in XElement.Load(@"D:\product.xml").Elements("Brand"))
                    {
                        result.AppendLine(level1Element.Attribute("name").Value);
                        foreach (XElement level2Element in level1Element.Elements("product"))
                        {
                            result.AppendLine("  " + level2Element.Attribute("name").Value);
                        }
                    }
           
                
       
