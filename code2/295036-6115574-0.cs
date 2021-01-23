    public class MyTextBox : TextBox
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.K)
            {
                int pos = this.SelectionStart;
                this.Text = this.Text.Substring(0, this.SelectionStart) + "jj" 
                + this.Text.Substring(this.SelectionStart);
                this.SelectionStart = pos + 2;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
