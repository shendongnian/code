    public UserControl1()
    {
      InitializeComponent();
      base.AutoScaleMode = AutoScaleMode.None;
    }
    [Description("Sets the font of the button caption")]
    public override Font Font
    {
      get { return _Font; }
      set { _Font = base.Font = value; }
    }
