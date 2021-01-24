        public static List<Node> GetAllNodes(List<Node> items)
        {
            List<Node> allNodes = new List<Node>();
            foreach(Node n in items)
                if (n.Nodes != null && n.Nodes.Count > 0)
                    allNodes.AddRange(GetAllNodes(n.Nodes));
            allNodes.AddRange(items);
            return allNodes;
        }
