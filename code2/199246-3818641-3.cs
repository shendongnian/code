            public static void RemoveComments(HtmlNode node)
            {
                foreach (var n in node.ChildNodes.ToArray())
                    RemoveComments(n);
                if (node.NodeType == HtmlNodeType.Comment)
                    node.Remove();
            }
            static void Main(string[] args)
            {
                var doc = new HtmlDocument();
                string html = @"<!--[if gte mso 9]>
    ...
    <![endif]-->
    <body>
        <span>
            <!-- comment -->
        </span>
        <!-- another comment -->
    </body>
    <!--[if gte mso 10]>
    ...
    <![endif]-->";
                doc.LoadHtml(html);
                RemoveComments(doc.DocumentNode);
                Console.WriteLine(doc.DocumentNode.OuterHtml);
                Console.ReadLine();
            }
