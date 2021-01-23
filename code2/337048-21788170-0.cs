        if (!Page.IsPostBack)
        {
            MenuDS ds = new MenuDS();
            CategoryTableAdapter daCategory = new CategoryTableAdapter();
            ProductTableAdapter daProduct = new ProductTableAdapter();
            daCategory.Fill(ds.Category);
            daProduct.Fill(ds.Product);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TreeView1.Nodes.Clear();
                foreach (DataRow dr in ds.Category.Rows)
                {
                    TreeNode mastreNode = new TreeNode(dr["cateNAme"].ToString(), dr["Id"].ToString());
                    TreeView1.Nodes.Add(mastreNode);
                    TreeView1.CollapseAll();
                    DataTable dt = daProduct.GetDataBy(Convert.ToInt32((dr["Id"])));
                    foreach (DataRow drNew in dt.Rows)
                    {
                        TreeNode childNode = new TreeNode(drNew["prodName"].ToString(), drNew["Id"].ToString());
                        childNode.NavigateUrl = "~/ProductDetails.aspx?Id=" + drNew["Id"].ToString();
                        mastreNode.ChildNodes.Add(childNode);
                    }
                }
            }
        }
        
        
    }
