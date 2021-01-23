        public class NewTreeView : System.Windows.Forms.TreeView
        {
            protected override void WndProc(ref System.Windows.Forms.Message m)
            {
                const int WM_RBUTTONDOWN = 0x204;
                if (m.Msg == WM_RBUTTONDOWN)
                {
                    //Create and show a context menu
                    var myContextMenu = new ContextMenuStrip();
                    myContextMenu.Items.Add("First Item");
                    myContextMenu.Items.Add("Second Item");
                    return;
                }
                base.WndProc(ref m);
            }   
        }
