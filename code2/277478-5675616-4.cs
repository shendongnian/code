        public class FixedTreeView : System.Windows.Forms.TreeView
        {
            protected override void WndProc(ref System.Windows.Forms.Message m)
            {
                const int WM_RBUTTONDOWN = 0x204;
                if (m.Msg == WM_RBUTTONDOWN)
                {
                    Point mousePos = this.PointToClient(Control.MousePosition);
                    this.SelectedNode = this.GetNodeAt(mousePos);
                }
                base.WndProc(ref m);
            }   
        }
