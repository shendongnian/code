    public static void ImportDirectives()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "directives.xml";
            // Create XML elements from a source file.
            XElement xTree = XElement.Load(fileName);
            // Create an enumerable collection of the elements.
            IEnumerable<XElement> elements = xTree.Elements();
            // Evaluate each element and set set values in the book object.
            foreach (XElement el in elements)
            {
                string directive = el.Attribute("directive").Value;
                string response = el.Attribute("response").Value;
                Console.WriteLine(directive + ":" + response);
            }
        }
