    protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["type"] == null)
            {
                RemoveNodeRecurrently(rptTree.Nodes, "Create Users");
            }
            
            if (Session["user"] != null)
            {
            }
            else
            {
                Response.Redirect(ConfigurationManager.AppSettings.Get("RootFolder") + "/ERP - Login.aspx");
            }
        }
        private void RemoveNodeRecurrently(TreeNodeCollection childNodeCollection, string text)
        {
            foreach (TreeNode childNode in childNodeCollection)
            {
                if (childNode.ChildNodes.Count > 0)
                    RemoveNodeRecurrently(childNode.ChildNodes, text);
                if (childNode.Text == text)
                {
                    TreeNode parentNode = childNode.Parent;
                    parentNode.ChildNodes.Remove(childNode);
                    break;
                }
            }
        }
