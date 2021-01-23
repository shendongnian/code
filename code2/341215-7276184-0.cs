            var head = document.DocumentNode.SelectSingleNode("html/head");
            var nodes = new List<HtmlNode>();
            bool isComment = false;
            foreach (var node in head.ChildNodes.ToList())
            {
                if (node.NodeType == HtmlNodeType.Comment &&
                    node.InnerText.Contains("WidgetScript_WidgetName"))
                {
                    isComment = !isComment;
                    node.Remove();
                }
                else if (isComment)
                {
                    nodes.Add(node);
                    node.Remove();
                }
            }
            Console.WriteLine(head.InnerHtml);
