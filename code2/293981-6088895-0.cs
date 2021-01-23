    public class FocusChangeTextBox : TextBox
    {
        public FocusChangeTextBox()
        {
        }
        protected override void OnGotFocus(EventArgs e)
        {
            // Call the base class implementation
            base.OnGotFocus();
            // Implement your own custom behavior
            this.BackColor = SystemColors.Window;
        }
        protected override void OnLostFocus(EventArgs e)
        {
            // Call the base class implementation
            base.OnLostFocus();
            // Implement your own custom behavior
            this.BackColor = Color.LightSteelBlue;
        }
    }
