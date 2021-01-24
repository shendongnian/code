    public static readonly DependencyProperty IsEditEnabledProperty = DependencyProperty.Register(
      "IsEditEnabled",
      typeof(bool),
      typeof(MainWindow),
      new PropertyMetadata(default(bool)));
    
    public bool IsEditEnabled { get { return (bool) GetValue(MainWindow.IsEditEnabledProperty); } set { SetValue(MainWindow.IsEditEnabledProperty, value); } }
