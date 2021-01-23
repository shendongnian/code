    TreeNode parentNode = t1.Parent;
    if (parentNode != null}
    {
        if(parentNode.Nodes.Cast<TreeNode>().ToList().Find(t => t.Text.Equals(node["DEPARTMENT"].InnerXml) == null)
        {
            //Add node
        }
    }
    else
    {
        bool isFound = true;
        if (treeView1.Nodes.Cast<TreeNode>().ToList().Find(t => t.Text.Equals(node["DEPARTMENT"].InnerXml) == null)
        {
            isFound = false;
        }
        if(!isFound)
        {
            //Add node
        }
    }
