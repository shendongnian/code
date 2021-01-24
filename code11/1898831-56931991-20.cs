    public static readonly DependencyProperty SelectedPageProperty = DependencyProperty.Register(
      "SelectedPage",
      typeof(object),
      typeof(UserControl),
      new PropertyMetadata(default(object)));
    
    public object SelectedPage { get { return (object) GetValue(MainWindow.IsEditEnabledProperty); } set { SetValue(MainWindow.IsEditEnabledProperty, value); } }
