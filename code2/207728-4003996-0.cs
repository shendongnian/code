    public KindsEditor()
    {
        InitializeComponent();
        if (!DesignerProperties.GetIsInDesignMode(this))
            DataBindings.Add("ButtonsEnabled", this, "RequiredDataLoaded");
    }
