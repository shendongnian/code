    private void myButton_Click(object sender, RoutedEventArgs e)
    {
      if (_adorner == null)
      {
        _adorner = new FrameworkElementAdorner(myGrid);
      }
      // remove the button from the parent panel and attach it to the adorner
      // otherwise remove from adorner and attach to original parent again
      if (_adorner.IsVisible)
      {
        AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(myGrid);
        adornerLayer.Remove(_adorner);
        Panel parent = VisualTreeHelper.GetParent(myButton) as Panel;
        if (parent != null)
        {
          parent.Children.Remove(myButton);
        }
        _originalParent.Children.Add(myButton);
      }
      else
      {
        _originalParent = VisualTreeHelper.GetParent(myButton) as Panel;
        if (_originalParent != null)
        {
          _originalParent.Children.Remove(myButton);
        }
        // Create the Adorner with the original button in it
        _adorner.Child = CreateAdornerContent(myButton);
        AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(myGrid);
        adornerLayer.Add(_adorner);
      }
    }
    /// <summary>
    /// Creates some dummy content for the adorner
    /// </summary>
    private FrameworkElement CreateAdornerContent(Button myButton)
    {
      Grid g = new Grid();
      g.Background = new SolidColorBrush(Colors.Yellow);
      TextBlock tb = new TextBlock();
      tb.Text = "I am the Adorner";
      g.Children.Add(tb);
      g.Children.Add(myButton);
      return g;
    }
