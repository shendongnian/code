    using System;
    using System.Windows.Forms;
    
    public class MyUpDown : NumericUpDown {
        public override void UpButton() {
            decimal inc = this.Increment;
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) this.Increment *= 10;
            base.UpButton();
            this.Increment = inc;
        }
        // TODO: DownButton
    }
