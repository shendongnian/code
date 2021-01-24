          public static void ImportDirectives()
            {
                // Create XML elements from a source file.
                XElement xTree = XElement.Load(AppDomain.CurrentDomain.BaseDirectory + "directives.xml");
    
                // Create an enumerable collection of the elements.
                IEnumerable<XElement> elements = xTree.Elements();
    
                // Evaluate each element and set set values in the book object.
                foreach (XElement el in elements.Elements())
                {
                    Directive dir = new Directive();
                    dir.directive = el.Attribute("directive").Value;
                    IEnumerable<XElement> props = el.Elements();
                    foreach (XElement p in props)
                    {
                        if (p.Name.ToString().ToLower() == "response")
                        {
                            dir.response = p.Value;
                        }
                    }
                    Dir.Add(dir);
                }
            }
