    var doc = XDocument.Load("test.xml", LoadOptions.PreserveWhitespace);
    foreach (var node in doc.DescendantNodes())
    {
        if (node is XElement elem)
        {
            Console.WriteLine("Element: " + elem.Name);
        }
        if (node is XText text)
        {
            Console.WriteLine("Text: " + 
                string.Join(", ", text.Value.Select(c => ((int)c).ToString("X"))));
        }
    }
