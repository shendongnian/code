    internal class myLabel : Label
    {
        const int WM_MOUSEWHEEL = 0x020A;
    
        protected override void WndProc(ref Message m)
        {
    
            if (m.Msg == WM_MOUSEWHEEL)
                m.HWnd = this.Parent.Handle; 
    
            base.WndProc(ref m);
        }
    }
