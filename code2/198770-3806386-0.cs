    using System;
    using System.Windows.Forms;
    
    class RichLabel : RichTextBox {
        public RichLabel() {
            this.ReadOnly = true;
            this.TabStop = false;
            this.SetStyle(ControlStyles.Selectable, false);
        }
        protected override void OnEnter(EventArgs e) {
            if (!DesignMode) this.Parent.SelectNextControl(this, true, true, true, true);
            base.OnEnter(e);
        }
        protected override void WndProc(ref Message m) {
            if (m.Msg < 0x201 || m.Msg > 0x20e)
                base.WndProc(ref m);
        }
    }
