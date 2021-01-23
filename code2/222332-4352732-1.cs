    private ParentWindow parent;
    public TutorialWindow(ParentWindow parent)
    {
        InitializeComponent();
        this.parent = parent;
    }
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        this.parent.Window_MouseDown(sender, e);
    }
