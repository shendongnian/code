    public partial class GuiDefault // not my whole class, just an example
    { 
    TreeNode checkedNode = null;
        private void Tree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode checkedNodeVar = e.Node;
            if (checkedNodeVar.Checked)
                        {
                        
                            if (checkedNode != null)
                            {
                                checkedNode.Checked = false; // set "checked" property of the last checked box to false
                            }
                                
                            checkedNode = checkedNodeVar; // set the class property "checkedNode" to the currently checked Node
                        }
            else
                        {
                            checkedNode = null; // if current checked box gets unchecked again, also reset the class property "checkedNode"
                        }
        }
    }
