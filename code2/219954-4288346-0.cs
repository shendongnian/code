    using System;
    using System.Windows.Forms;
    
    class MyComboBox : ComboBox {
        protected override void OnResize(EventArgs e) {
            if (!this.Focused && this.DropDownStyle == ComboBoxStyle.DropDown) {
                this.SelectionLength = 0;
            }
            base.OnResize(e);
        }
    }
