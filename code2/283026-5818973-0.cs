    public static List<string> GetFamiliesList()
        {
            List<string> families = new List<string>();
            try
            {
                using (StreamReader streamreader = new StreamReader(Server.MapPath(filepath)))
                {
                    XElement xe = XElement.Load(streamreader);
                    foreach (XElement children in xe.Elements("Family"))
                    {
                        families.Add(children.Attribute("Name").Value);
                    }
                }
            }
            catch
            {
                
            }
            return families;
        }
