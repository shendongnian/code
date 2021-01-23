    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Size Size { get; set; }
    
    public Size Size2 { 
       get { return base.Size; }
       set { base.Size = value; }
    }
