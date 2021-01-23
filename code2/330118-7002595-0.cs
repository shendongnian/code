    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    class FancyTextBox : TextBox {
        public FancyTextBox() {
            TreatEnterAsTab = true;
        }
        [DefaultValue(true)]
        public bool TreatEnterAsTab { get; set; }
    
        public override bool PreProcessMessage(ref Message msg) {
            if (TreatEnterAsTab && (!this.Multiline || this.AcceptsReturn) && 
                Control.ModifierKeys == Keys.None && 
                msg.Msg == WM_KEYDOWN && (Keys)msg.WParam.ToInt32() == Keys.Enter) {
                  msg.WParam = (IntPtr)Keys.Tab;
            }
            return base.PreProcessMessage(ref msg);
        }
        private const int WM_KEYDOWN = 0x100;
    }
