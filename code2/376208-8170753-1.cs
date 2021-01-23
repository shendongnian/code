        XDocument input = XDocument.Load("input.xml");
        XDocument output = new XDocument(
            new XElement(input.Root.Name,
                from el in input.Root.Elements()
                where el.Elements().Any()
                group el by el.NodesBeforeSelf().OfType<XElement>().LastOrDefault(e => !e.Elements().Any()) into g
                select new XElement(g.Key.Name,
                    g.Key.Attributes(),
                    g.Key.Nodes(),
                    g)
                ));
        output.Save(Console.Out);
