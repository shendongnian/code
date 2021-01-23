    using System;
    using System.Windows.Forms;
    
    class MyComboBox : ComboBox {
        protected override void OnSelectedIndexChanged(EventArgs e) {
            // Here
            //...
            base.OnSelectedIndexChanged(e);
        }
    }
