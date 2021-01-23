        // walk the tree in DFS
        public void XmlTreeWalk(XmlNode root, Action<XmlNode, XmlNode> action)
        {
            var nodesToCompare = new Stack<XmlNode>();
            foreach (XmlNode child in root.ChildNodes)
            {
                nodesToCompare.Push(child);
            }
            while (nodesToCompare.Count > 0)
            {
                var top = nodesToCompare.Pop();
                action(root, top);
                foreach (XmlNode child in top.ChildNodes)
                {
                    nodesToCompare.Push(child);
                }
            }
        }
        // for each node: prepare all its children for deletion
        public void PrepareForDeletion(XmlNode root)
        {
            XmlTreeWalk(root, (r, c) => PrepareSubtreeForDeletion(r, c));
        }
        // for each node, compare all its children against the toCompare node
        private void PrepareSubtreeForDeletion(XmlNode toCompare, XmlNode root)
        {
            XmlTreeWalk(root, (unused, current) => MarkNodeForDeletion(toCompare, current));
        }
        // your delete logic
        public void MarkNodeForDeletion(XmlNode toCompare, XmlNode toCompareAgains)
        {
           ...
        }
