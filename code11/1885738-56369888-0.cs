    class TextBoxHandler
    {
        private readonly TextBox _textbox;
        public TextBoxHandler(TextBox textbox)
        {
            _textbox = textbox;
            _textbox.Click += HandleClick;
        }
        public void HandleClick(object sender, EventArgs e)
        {
            //Do something
        }
    }
