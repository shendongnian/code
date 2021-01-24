    public bool Designtime { get; set; }
    public ViewModel()
    {
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
        {
            Designtime = true;
        }
    }
