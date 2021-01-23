    using System;
    using System.Windows.Forms;
    
    class MyTexBox : TextBox {
        protected override bool IsInputKey(Keys keyData) {
            if (keyData == Keys.Escape) return true;
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e) {
            if (e.KeyData == Keys.Escape) {
                this.Text = "";   // for example
                e.SuppressKeyPress = true;
                return;
            }
            base.OnKeyDown(e);
        }
    }
