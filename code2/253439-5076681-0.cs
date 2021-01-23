    // just a concept, not tested, might have errors
    // ObjectWithHierarchy could look something like this
    class ObjectWithHierarchy
    {
        public int Id {get;set;}
        public int? ParentId {get;set;}
        public string Name {get;set;}
    }
    private void LoadTree()
    {
        // initialize your collection of objects
        List<ObjectWithHierarchy> list = new List<ObjectWithHierarchy>();
    
        // build the tree
        TreeView treeView = new TreeView();
    
        foreach (var item in list.FindAll(i => i.ParentId == null))
        {
            // create the root node
            TreeNode rootNode = new TreeNode();
            rootNode.Text = item.Name; 
            rootNode.Tag = item;
            // load child nodes
            LoadChildNodes(node, list);
            // add the node to the treeview
            treeView.Nodes.Add(rootNode);
        }
    }
    private void LoadChildNodes(TreeNode node, List<ObjectWithHierarchy> list)
    {
        ObjectWithHierarchy item = node.Tag as ObjectWithHierarchy;
        foreach (var childItem in list.FindAll(i => i.ParentId == item.Id))
        {
            // create the child node
            TreeNode childNode = new TreeNode();
            childNode.Text = childItem.Name;
            childNode.Tag = childItem;
            // load children, if there are any
            LoadChildNodes(childNode, list);
            // add it to its parent nodes collection
            node.Nodes.Add(childNode);
        }
    }
