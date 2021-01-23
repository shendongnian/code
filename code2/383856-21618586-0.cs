       XmlTextReader xtr = new XmlTextReader(new StringReader(xml));
       XElement items = XElement.Load(xtr);
       foreach (string desc in items.Elements("Item").Select(i => (string)i.Attribute("Description")))
       {
           Console.WriteLine("|{0}|", desc);
       }
