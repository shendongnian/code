    public void AddView(YourUserControl someView)
    {
        InitializeComponent();
        someView.RemoveClicked += HandleThatEvent;
    }
