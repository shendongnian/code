    public class ActivatingMenuStrip : MenuStrip
    {
        public ActivatingMenuStrip()
        {
            InitializeComponent();
        }
        int WM_MOUSEACTIVATE = 0x21;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                this.Parent.Focus();
            }
            base.WndProc(ref m);
        }
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
    }
