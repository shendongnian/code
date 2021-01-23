    public class ClickableTextBox : TextBox
    {
        public ClickableTextBox()
        {
            this.Click += MyClickHandler;
        }
        
        private void MyClickHandler(object sender, MouseEventArgs e)
        {
            this.ForeColor = Color.Black;
            this.Text = input;
        }
    }
