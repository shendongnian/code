    internal class SmartTextBox : TextBox
    {
        public SmartTextBox()
        {
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                // validate 'value' before setting it
                base.Text = value;
            }
        }
    }
