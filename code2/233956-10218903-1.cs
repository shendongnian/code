    public class RadioButtonEx : RadioButton
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down)
            {
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
