    private IEnumerable<TreeNode> ModifyGetUNNodes(string NodeName, bool nodeVale)
        {
            var checkUnNodes = new List<TreeNode>();
            GetUnNodes(checkUnNodes, ModifyTreeView.Nodes, NodeName, nodeVale);
            return checkUnNodes;
        }
    
        // Return a list of the TreeNodes that are checked.
        private static void GetNodes(ICollection<TreeNode> checkedNodes, IEnumerable nodes, string nodeName, bool checkValue)
        {
            foreach (TreeNode node in nodes)
            {
                if(node.Text == nodeName)
                   node.Checked = checkValue;
    
                // Check the node's descendants.
                GetNodes(checkedNodes, node.Nodes);
            }
        }
In this code i just passed two more args and checked the Node.text and set it as checked and UnChecked form the Data Column Values.
Now i call The Function with passing **args** name of node and checked value 
Example : 
    
        var getData = DbContext.tblMenu.Select(x => x).ToList();
       foreach(var y in getData)
        {
         ModifyGetUNNodes("Bread", y.Bread.value);
        }
Here the y.Bread is column name which holds the checked value(True or False).
       
