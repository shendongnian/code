        static void Main(string[] args)
        {
            var list = new List<String>()
            {
                "child.child2.child3",
                "child7",
                "child10.child14.child15",
                "child10.child14.child16"
            };
            var matrix = new List<List<String>>();
            foreach (var line in list)
            {
                matrix.Add(line.Split('.').ToList());
            }
            StringBuilder html = new StringBuilder();
            WriteLevel(html, matrix, 0);
            Console.WriteLine(html.ToString());
        }
        static void WriteLevel(StringBuilder html, List<List<String>> matrix, int level)
        {
            var nodes = from node in matrix
                        where node.Count > level
                        group node by node[level] into grouping
                        select grouping;
            if (nodes.Count() > 0)
            {
                html.Append("<ul>");
                foreach (var node in nodes)
                {
                    html.Append("<li>");
                    html.Append(node.Key);
                    WriteLevel(html, node.ToList(), level + 1);
                    html.Append("</li>");
                }
                html.Append("</ul>");
            }
        }
