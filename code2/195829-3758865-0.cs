        public void modifyPassedAttribute(string myFile, string attributeName, string attributeType)
        {
            Object objString = (Object)attributeName;
            string strType = "nvarchar";
            string smallintType = "smallint";
            string intType = "int";
            string dateType = "datetime";            
            XDocument myDoc = XDocument.Load(myFile);
            
            //var myAttr = from el in myDoc.Root.Elements()
            //                    from attr in el.Attributes()
            //                    where attr.Name.ToString().Equals(attributeName)
            //                    select attr;
            var attrib = myDoc.Descendants().Attributes().Where(a => a.Name.LocalName.Equals(objString));
            foreach (XAttribute elem in attrib)
            {
                Console.WriteLine("ATTRIBUTE NAME IS {0} and of Type {1}", elem, elem.Value.GetType());
                if (strType.Equals(attributeType))
                {
                    if (elem.Value.EndsWith("_change"))
                    {
                        elem.Value = elem.Value.Replace("_change", "");
                        Console.WriteLine("NEW VALUE IS {0}", elem.Value);
                    }
                    else
                    {
                        elem.Value += "_change";
                        Console.WriteLine("NEW VALUE IS {0}", elem.Value);
                    }
                }
                else if (smallintType.Equals(attributeType))
                {
                    if (elem.Value.EndsWith("2"))
                    {
                        elem.Value = elem.Value.Replace("2", "");
                        Console.WriteLine("NEW VALUE IS {0}", elem.Value);
                    }
                    else
                    {
                        elem.Value += 2;
                        Console.WriteLine("NEW VALUE IS {0}", elem.Value);
                    }
                }
                else if (intType.Equals(attributeType))
                {
                    if (elem.Value.EndsWith("2"))
                    {
                        elem.Value = elem.Value.Replace("2", "");
                        Console.WriteLine("NEW VALUE IS {0}", elem.Value);
                    }
                    else
                    {
                        elem.Value += 2;
                        Console.WriteLine("NEW VALUE IS {0}", elem.Value);
                    }
                }
                else if (dateType.Equals(attributeType))
                {
                    if (elem.Value.EndsWith("2"))
                    {
                        elem.Value = elem.Value.Replace("2", "");
                        Console.WriteLine("NEW VALUE IS {0}", elem.Value);
                    }
                    else
                    {
                        elem.Value += 2;
                        Console.WriteLine("NEW VALUE IS {0}", elem.Value);
                    }
                }
            }
            myDoc.Save(myFile);
        }
