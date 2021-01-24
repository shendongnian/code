    public partial class EscapeForm : Form
    {      
        //You will put there your method
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
    
            return base.ProcessDialogKey(keyData);
        }
    }
