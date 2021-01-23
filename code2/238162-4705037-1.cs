    static void Main(string[] args)
    {
        XDocument doc = XDocument.Load(@"..\..\XMLFile1.xml");
        foreach (XElement prop in doc.Descendants("Property"))
        {
            XDocument result = new XDocument(
                new XElement(doc.Root.Name, doc.Root.Attributes(),
                    doc.Root.Elements("Global"),
                    CopySubtree(prop.Ancestors("local").First(), prop)));
            result.Save(Console.Out);
            Console.WriteLine();
        }
    }
    static XElement CopySubtree(XElement ancestor, XElement descendant)
    {
        if (ancestor == descendant)
        {
            return descendant;
        }
        else
        {
            return
                new XElement(
                    ancestor.Name, 
                    ancestor.Attributes(), 
                    CopySubtree(
                      ancestor
                      .Elements()
                      .First(e => e.DescendantsAndSelf().Any(d => d == descendant)),
                      descendant));
        }
    }
