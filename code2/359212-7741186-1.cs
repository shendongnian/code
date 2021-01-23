    public class ClickableTextBox : TextBox
    {
        public ClickableTextBox()
        {
            this.Click += MyClickHandler;
        }
        void setText(string input)
        {
            this.ForeColor = Color.Black;
            this.Text = input;
        }
        
        private void MyClickHandler(object sender, MouseEventArgs e)
        {
            setText(Clipboard.GetText());
        }
    }
