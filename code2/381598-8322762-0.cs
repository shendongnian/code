    private void getNodeList()
    {
        //This will hold your node text
        List<string> nodeTextList = new List<string>();
        //loop through all teeview nodes
        foreach(TreeNode rootNode in treeView.Nodes)
        {
           //Add root node to list
           nodeTextList.Add(rootNode.Text);
           //Do recursive getter to get child nodes of root node
           getChildNodes(rootNode, nodeTextList);
           
        }
        //Do with nodeTextList what ever you want, for example add to datatable.
    }
    
    private void getChildNodes(TreeNode rootNode, List<string> nodeTextList)
    {
       foreach(TreeNode childNode in rootNode.Nodes)
       {
           //Add child node text
           nodeTextList.Add(childNode.Text);      
           getChildNodes(childNode, nodeTextList);
       }
    }
