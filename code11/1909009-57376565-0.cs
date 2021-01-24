    public static readonly DependencyProperty FeedbackTextProperty = DependencyProperty.Register(
      "FeedbackText",
      typeof(string),
      typeof(MainWindow),
      new PropertyMetadata(default(string)));
    public string FeedbackText
    {
      get => (string) GetValue(MainWindow.TextProperty);
      set => SetValue(MainWindow.TextProperty, value);
    }
