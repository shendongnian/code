    public class MyTreeView : TreeView
    {
        int WM_LBUTTONDOWN = 0x0201; //513
        int WM_LBUTTONUP = 0x0202; //514
        int WM_LBUTTONDBLCLK = 0x0203; //515
    
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN ||
               m.Msg == WM_LBUTTONUP ||
               m.Msg == WM_LBUTTONDBLCLK)
            {
                //Get cursor position(in client coordinates)
                Int16 x = (Int16)m.LParam;
                Int16 y = (Int16)((int)m.LParam >> 16);
    
                // get infos about the location that will be clicked
                var info = this.HitTest(x, y);
    
                // if the location is a node
                if (info.Node != null)
                {
                    // if is not a root disable any click event
                    if(info.Node.Parent != null)
                        return;//Dont dispatch message
                }
            }
    
            //Dispatch as usual
            base.WndProc(ref m);
        }
    }
