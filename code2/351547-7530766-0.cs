    public static readonly DependencyProperty MyTopmostProperty =
      DependencyProperty.Register("MyTopmost",
        typeof(bool),
        typeof(MyWindow),
        new FrameworkPropertyMetadata {
          PropertyChangedCallback = new PropertyChangedCallback(OnMyTopmostChanged)
        }
    );
