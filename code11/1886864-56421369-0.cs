    ButtonBase clickButtonPart = null;
    public const string ClickButtonTemplatePartName = "ClickButton";
    public event EventHandler Click;
    protected override void OnApplyTemplate()
    {
      // In case the template changes, you want to stop listening to the
      // old button's Click event.
      if (clickButtonPart != null)
      {
        clickButtonPart.Click -= ClickForwarder;
        clickButtonPart = null;
      }
      // Find the template child with the special name. It can be any kind
      // of ButtonBase in this example.
      clickButtonPart = GetTemplateChild(ClickButtonTemplatePartName) as ButtonBase;
      // Add a handler to its Click event that simply forwards it on to our
      // Click event.
      if (clickButtonPart != null)
      {
        clickButtonPart.Click += ClickForwarder;
      }
    }
    private void ClickForwarder(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
      Click?.Invoke(this, null);
    }
