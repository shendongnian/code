    using System;
    using System.Windows.Forms;
    
    class MyLayoutPanel : TableLayoutPanel {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            var ctl = this.FindForm().ActiveControl;
            if (ctl.Parent == this) {
                int col = this.GetColumn(ctl);
                int row = this.GetRow(ctl);
                if (keyData == Keys.Left && col > 0) {
                    var newctl = this.GetControlFromPosition(col - 1, row);
                    if (newctl != null) newctl.Focus();
                    return true;
                }
                // etc..
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
