     public class Custom_Tree_View : System.Windows.Forms.TreeView
    {
        DataSet dsMenu = new DataSet();
        public TreeNodeMouseClickEventHandler TreeNode_Click_Event;
        float FontSize = 9F;
        string FontName = "Tahoma";
        public string Data_Key_Member;
        public string Data_Key_Value;
        private ImageList imageList1;
        private System.ComponentModel.IContainer components;
        public string Data_Parent_Key;
        public bool ShowCheckBox = false;
        public Custom_Tree_View()
        {
            this.Font = new System.Drawing.Font(this.FontName, this.FontSize);          
            this.NodeMouseClick += NodeMouseClicked;
        }
        public void CreateMenu(DataSet _dsMenu)
        {
            try
            {
                this.Nodes.Clear();
                if (_dsMenu == null) return;
                this.CheckBoxes = this.ShowCheckBox;
                this.dsMenu = _dsMenu;
                string Filter = this.Data_Parent_Key + " IS NULL";
                foreach (DataRow drTemp in dsMenu.Tables[0].Select(Filter))
                {
                    Create_Parent_Tree_Node(drTemp[0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Create_Parent_Tree_Node(string strMenu)
        {
            try
            {
                TreeNode mmru = new TreeNode(GetMenu_Details_Title(strMenu));
                mmru.Name = strMenu;
                if (dsMenu.Tables[0].Select(this.Data_Parent_Key + "='" + strMenu + "'").Length > 0)
                {
                    this.Nodes.Add(mmru);
                    foreach (DataRow drTemp in dsMenu.Tables[0].Select(this.Data_Parent_Key + "='" + strMenu + "'"))
                    {
                        Create_Child_Tree_Node(mmru, drTemp[0].ToString());
                    }
                }
                else
                {
                    mmru.ForeColor = System.Drawing.Color.Red;
                    this.Nodes.Add(mmru);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string Create_Child_Tree_Node(TreeNode mnuItem, string strMenu)
        {
            try
            {
                if (dsMenu.Tables[0].Select(this.Data_Parent_Key + "='" + strMenu + "'").Length > 0)
                {
                    TreeNode mmru = new TreeNode(GetMenu_Details_Title(strMenu));
                    mmru.Name = strMenu;
                    mnuItem.Nodes.Add(mmru);
                    foreach (DataRow drTemp1 in dsMenu.Tables[0].Select(this.Data_Parent_Key + "='" + strMenu + "'"))
                    {
                        Create_Child_Tree_Node(mmru, drTemp1[0].ToString());
                    }
                }
                else
                {
                    TreeNode mmru = new TreeNode(GetMenu_Details_Title(strMenu));
                    mmru.Name = strMenu;
                    mmru.ForeColor = System.Drawing.Color.Red;
                    mnuItem.Nodes.Add(mmru);
                    return strMenu;
                }
                return strMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GetMenu_Details_Title(string TreeNode_ID)
        {
            try
            {              
                return dsMenu.Tables[0].Select(this.Data_Key_Value + "=" + TreeNode_ID + "")[0][this.Data_Key_Member].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool GetMenuEnable(string TreeNode_ID)
        {
            try
            {
                if (dsMenu.Tables[0].Select(this.Data_Key_Value + "='" + TreeNode_ID + "'")[0][3].ToString() == "Y")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TreeNode SelectedTreeNode;
        private void NodeMouseClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {                
                if (dsMenu.Tables[0].Select(this.Data_Parent_Key + "='" + e.Node.Name + "'").Length > 0)
                {
                    return;
                }
                else
                {
                    if (this.TreeNode_Click_Event != null)
                        TreeNode_Click_Event(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Custom_Tree_View
            // 
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ItemHeight = 25;
            this.LineColor = System.Drawing.Color.Black;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Custom_Tree_View_NodeMouseClick);
           
            this.ResumeLayout(false);
        }
        
        private void Custom_Tree_View_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Checked == true)
                {
                    foreach (TreeNode Node in e.Node.Nodes)
                    {
                        Node.Checked = true;
                    }
                }
                if (e.Node.Checked == false)
                {
                    foreach (TreeNode Node in e.Node.Nodes)
                    {
                        Node.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
