    public class TestControl : CompositeControl
    {
        private TextBox textBox;
        public string TextBoxClientID
        {
            get
            {
                return textBox.ClientID;
            }
        }
        protected override void CreateChildControls()
        {
            textBox = new TextBox();
            textBox.ID = "textBox1";
            Controls.Add(textBox);
        }
    }
