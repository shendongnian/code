    public class MyDataGridView : DataGridView
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.J))
            {
                this.ProcessDownKey(Keys.Down);
    
                return true;
            }
    
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
