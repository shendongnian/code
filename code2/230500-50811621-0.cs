    public static readonly DependencyProperty MyDependencyProperty =
                       DependencyProperty.Register(
                             "Dependency",
                              typeof(string),
                              typeof(MyUserControl),
                              new FrameworkPropertyMetadata("Initializing...", new PropertyChangedCallback(OnMyDependencyChangedCallBack)));
