    private void PopulateTreeView()
    {
        DataSet ds = new DataSet(); //(populate the dataset with the table)
        //Use LINQ to filter out items without a parent
        DataTable parents = ds.Tables[0].AsEnumerable()
            .Where(i => i.Field<object>("parentid") == DBNull.Value)
            .CopyToDataTable();
        //Use LINQ to filter out items with parent
        DataTable children = ds.Tables[0].AsEnumerable()
            .Where(i => i.Field<object>("parentid") != DBNull.Value)
            .OrderBy(i => i.Field<int>("parentid"))
            .CopyToDataTable();
        //Add the parents to the treeview
        foreach(DataRow dr in parents)
        {
            TreeNode node = new TreeNode();
            node.Text = dr["name"].ToString();
            node.Value = dr["id"].ToString();
            TreeView1.Nodes.Add(node);
        }
        //Add the children to the parents
        foreach(DataRow dr in children)
        {
            TreeNode node = new TreeNode();
            node.Text = dr["name"].ToString();
            node.Value = dr["id"].ToString();
            TreeNode parentNode = FindNodeByValue(dr["parentid"].ToString());
            if(parentNode != null)
                parentNode.ChildNodes.Add(node);
        }
    }
    private TreeNode FindNodeByValue(string value)
    {
        foreach(TreeNode node in TreeView1.Nodes)
        {
            if(node.Value = value) return node;
            TreeNode pnode = FindNodeRecursion(node, value);
            if(pnode != null) return pnode;
        }
        return null;
    }
    private TreeNode FindNodeRecursion(TreeNode parentNode, string value)
    {
        foreach(TreeNode node in parentNode.ChildNodes)
        {
            if(node.Value = value) return node;
            TreeNode pnode = FindNodeRecursion(node, value);
            if(pnode != null) return pnode;
        }
        return null;
    }
