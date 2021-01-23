    public partial class Form1 : Form
    {
        private const int WM_MOUSEMOVE = 0x0200;
        
        // This is the Delphi-lookalike declaration for the WM_MOUSEMOVE handler.
        // I'd say it looks very much "alike!"
        [WinMessageHandler(WM_MOUSEMOVE)]
        public bool UnHandler(ref Message X)
        {
            this.Text = "Movement";
            return false;
        }
        // While simple, this is unfortunately a deal-breaker. If you need to go through the
        // trouble of writing this stub WndProc, might as well write a proper switch statement
        // and call the handler directly.
        protected override void WndProc(ref Message m)
        {
            if (!WinMessageDispatcher.Dispatch(this, ref m)) base.WndProc(ref m);
        }
    }
