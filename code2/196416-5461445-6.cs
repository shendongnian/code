    public class CustomTextBox : System.Windows.Forms.TextBox
    {
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Return)
                return true;
            return base.IsInputKey(keyData);
        }
    }
