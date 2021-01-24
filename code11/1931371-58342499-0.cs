    public ProjectItem Item => DataContext as ProjectItem;
    public MyUserControl1()
    {
        InitializeComponent();
        DataContextChanged += (s, e) => Bindings.Update();
    }
