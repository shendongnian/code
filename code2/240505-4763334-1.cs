    using System.Windows.Forms;
    public class MyComboBox : ComboBox
    {
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Tab)
                this.DroppedDown = false;
            return base.ProcessDialogKey(keyData);
        }
    }
