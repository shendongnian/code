     protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Dictionary<string, Int32> myList = new Dictionary<string, Int32>();
                myList.Add("Text1", 1);
                myList.Add("Text2", 2);
                myList.Add("Text3", 3);
                myList.Add("Text4", 4);
                myList.Add("Text5", 5);
    
                foreach (KeyValuePair<string, Int32> s in myList)
                {
                    this.TreeView1.Nodes.Add(new TreeNode(s.Key, s.Value.ToString()));
                    this.DropDownList1.Items.Add(new ListItem(s.Key, s.Value.ToString()));
                }
                foreach (TreeNode tn in this.TreeView1.Nodes)
                {
                    tn.ChildNodes.Add(new TreeNode("Hello World"));
                    tn.Collapse();
                }
            }
        }
    
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownList1.SelectedItem != null)
            {
                foreach (TreeNode tn in this.TreeView1.Nodes)
                {
                    if (tn.Value == this.DropDownList1.SelectedItem.Value)
                    {
                        tn.Selected = true;
                        if (tn.ChildNodes.Count > 0)
                        {
                            tn.Expand();
                        }
                    }
                    else {
                        tn.Collapse();
                    }
                }
            }
        }
