    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Description("Test text displayed in the link"), Category("Data")]
    public string LinkText
    {
         get { return this._linkText; }
         set
         {
             this._linkText = value;
             RefreshDisplay();
         }
    }
