    using System;
    using System.Windows.Forms;
    
    class RichPassword : RichTextBox {
        protected override CreateParams CreateParams {
            get {
                // Turn on ES_PASSWORD
                var cp = base.CreateParams;
                cp.Style |= 0x20;
                return cp;
            }
        }
    }
