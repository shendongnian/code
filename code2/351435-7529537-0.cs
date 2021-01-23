    public class MyTabPageHandlingCTRL : System.Windows.Forms.TabPage
    {
        const int WM_MOUSEWHEEL = 0x20A;
    
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
    
            if (m.HWnd != this.Handle)
                return;
            if (m.Msg == WM_MOUSEWHEEL && 
                (Control.ModifierKeys & Keys.Control) != Keys.Control)
            {
                return; // don't propagate the event
            }
            base.WndProc(ref m);
        }
    }
