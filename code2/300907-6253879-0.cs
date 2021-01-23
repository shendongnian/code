    public class RootNode : TreeNode
    {
        public List<ChildNode> ChildNodes { get; set; }
    
        public RootNode()
        {
            ChildNodes = new List<ChildNode>();
        }
    
        public void PopulateChildren()
        {
            this.Nodes.Clear();
          
            var visibleNodes = 
                ChildNodes
                .Where(x => x.Visible)
                .ToArray();
    
            this.Nodes.AddRange(visibleNodes);
        }
    
        //you would use this instead of (Nodes.Add)
        public void AddNode(ChildNode node)
        {
            if (!ChildNodes.Contains(node))
            {
                node.ParentNode = this;
                ChildNodes.Add(node);
                PopulateChildren();
            }
        }
    
        //you would use this instead of (Nodes.Remove)
        public void RemoveNode(ChildNode node)
        {
            if (ChildNodes.Contains(node))
            {
                node.ParentNode = null;
                ChildNodes.Remove(node);
                PopulateChildren();
            }
    
        }
    }
    
    public class ChildNode : TreeNode
    {
        public RootNode ParentNode { get; set; }
        private bool visible;
        public bool Visible { get { return visible; } set { visible = value;OnVisibleChanged(): } }
        private void OnVisibleChanged()
        {
            if (ParentNode != null)
            {
                ParentNode.PopulateChildren();
            }
        }
    }
