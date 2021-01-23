    private DateTime? _NextAllowedClick;
    private void Clicked(object sender, RoutedEventArgs e)
    {
       if (_NextAllowedClick != null && DateTime.Now < _NextAllowedClick)
       {
          return;
       }
       _NextAllowedClick = DateTime.Now + new TimeSpan(0, 0, 0, 2);
       ...
    }
