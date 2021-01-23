    using System;
    using System.Windows.Forms;
    
    class MyRtb : RichTextBox {
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x208) this.Clear();
            else if (m.Msg != 0x209) base.WndProc(ref m);
        }
    }
