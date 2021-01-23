    private void PopulateNodes(DataTable dt,TreeNodeCollection nodes)
    {
           foreach( DataRow dr in dt.Rows)
           {
                TreeNode tn=new TreeNode();
                tn.Text = dr["title"].ToString();
                tn.Value = dr["id"].ToString();
                tn.NavigateUrl = dr["url"].ToString();
                nodes.Add(tn);
                //If node has child nodes, then enable on-demand populating
                tn.PopulateOnDemand = ((int)(dr["childnodecount"]) > 0);
           }
    }
