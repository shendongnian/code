    public override void AttachView(object view, object context)
    {
      var frameworkElement = view as FrameworkElement;
      if (frameworkElement == null)
      {
        return;
      }
      var button = frameworkElement.FindName("myButton") as Button;
      if (button == null)
      {
        return;
      }
      // access button control here
    }
