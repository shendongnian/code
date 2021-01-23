    class CustomTreeView : System.Windows.Forms.TreeView
    {
        public event EventHandler<TreeNodeMouseClickEventArgs> CustomNodeClick;
    
        private const int WM_LBUTTONDOWN = 0x201;
    
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN)  // left mouse button down
            {
                // get the current position of the mouse pointer
                Point mousePos = Control.MousePosition;
    
                // get the node the user clicked on
                TreeNode testNode = GetNodeAt(PointToClient(mousePos));
    
                // see if the clicked area contained an actual node
                if (testNode != null)
                {
                    // A node was clicked, so raise our custom event
                    var e = new TreeNodeMouseClickEventArgs(testNode,
                                     MouseButtons.Left, 1, mousePos.X, mousePos.Y);
                    if (CustomNodeClick != null)
                        CustomNodeClick(this, e);
                }
            }
         
            // call through to let the base class process the message
            base.WndProc(ref m);
        }
    }
