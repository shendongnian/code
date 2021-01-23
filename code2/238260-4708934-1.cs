    // TreeNode tn = new TreeNode();
    // TreeNode tnSub = new TreeNode();               
    foreach (DataRow dt in tblTreeView.Rows)
    {
        TreeNode tn = new TreeNode();     // *
        tn.Text = dt[0].ToString();
        tn.Value = dt[0].ToString();
    
        TreeNode tnSub = new TreeNode();  // *
        tnSub.Text = dt[1].ToString();
        tnSub.NavigateUrl = "../downloading.aspx?file=" + dt[1].ToString() +"&user=" + userID;
        tn.ChildNodes.Add(tnSub);
        tvDocuments.Nodes.Add(tn);
    }
