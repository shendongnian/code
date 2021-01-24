        foreach (HtmlNode l in linkDoc.DocumentNode.SelectNodes("//p"))
        {
            if (l.ChildNodes.Any(node => node.Name == "a"))
            {
                Console.WriteLine();
                Console.Write("text #" + i++);
            }
            Console.Write(l.InnerText + " ");
        }
