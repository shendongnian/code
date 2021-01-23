    class Program
    {
        static void Main()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml("hello <div>bye bye</div> marco <img src=\"http://example.com\"/> test");
    
            for (int i = 0; i < doc.DocumentNode.ChildNodes.Count; i++)
            {
                var child = doc.DocumentNode.ChildNodes[i];
                if (child.NodeType == HtmlNodeType.Element && new[] { "div", "img" }.Contains(child.Name, StringComparer.OrdinalIgnoreCase))
                {
                    doc.DocumentNode.RemoveChild(child);
                }
            }
    
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                doc.Save(writer);
            }
            Console.WriteLine(sb); // prints "hello  marco  test"
         }
    
    }
