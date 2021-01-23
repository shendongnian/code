    class FooTextBox : TextBox
    {
        public FooTextBox()
        {
            margin = new Panel();
    
            margin.Enabled   = false;
            margin.BackColor = Color.LightGray;
            margin.Top       = 0;
            margin.Height    = ClientSize.Height;
            margin.Left      = <whatever>;
            margin.Width     = 1;
            Controls.Add(margin);
        }
        Panel margin;
    }
