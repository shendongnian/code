        public static IEnumerable<XmlNode> GetNodes(XmlDocument xdoc)
        {
            var nodes = new List<XmlNode>();
            Queue<XmlNode> toProcess = new Queue<XmlNode>();
            if (xdoc != null)
            {
                foreach (var node in GetChildElements(xdoc))
                {
                    toProcess.Enqueue(node);
                }
            }
            do
            {
                //get a node to process
                var node = toProcess.Dequeue();
                // add node to found list if name matches
                if (node.Name == "node")
                {
                    nodes.Add(node);
                }
                // get the node's children
                var children = GetChildElements(node);
                // add children to queue.
                foreach (var n in children)
                {
                    toProcess.Enqueue(n);
                }
                // continue while queue contains items.
            } while (toProcess.Count > 0);
            return nodes;
        }
        private static IEnumerable<XmlNode> GetChildElements(XmlNode node)
        {
            if (node == null || node.ChildNodes == null) return new List<XmlNode>();
            return node.ChildNodes.Cast<XmlNode>().Where(n=>n.NodeType == XmlNodeType.Element);
        }
