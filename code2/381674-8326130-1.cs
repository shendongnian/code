    public bool isPassword
            {
                set
                {
                    if (value) _value.TextMode = TextBoxMode.Password;
                }
            }
            public string ForeignKey
            {
                get { return hdnForeignKey.Value; }
                set { hdnForeignKey.Value = value; }
            }
    
            public string ControlLabel
            {
                get { return _controlLabel.Text; }
                set { _controlLabel.Text = value; }
            }
    
            public bool IsMandatory
            {
                get { return _isMandatory.Visible; }
                set { _isMandatory.Visible = value; }
            }
    
            public string Value
            {
                get { return _value.Text; }
                set { _value.Text = value; }
            }
    
            public bool IsReadyForInput
            {
                get { return _value.Enabled; }
                set { _value.Enabled = value; }
            }
    
            public string ControlLabelWidth
            {
                set { tdControlLabel.Width = value; }
            }
    
            public bool isTextArea
            {
                set
                {
                    if(value)
                    {
                        _value.TextMode = TextBoxMode.MultiLine;
                        _value.Rows = 5;
                    }
                    else
                    {
                        _value.TextMode = TextBoxMode.SingleLine;
                    }
                }
            }
            protected void Page_Load(object sender, EventArgs e)
            {
                _value.BackColor = System.Drawing.Color.White;
            }
