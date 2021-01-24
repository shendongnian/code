    public static bool TryFindVisualChildElementByName(
      this DependencyObject parent,
      string childElementName,
      out FrameworkElement resultElement)
    {
      if (parent is Popup popup)
      {
        parent = popup.Child;
      }
      resultElement = null;
      for (var childIndex = 0; childIndex < VisualTreeHelper.GetChildrenCount(parent); childIndex++)
      {
        DependencyObject childElement = VisualTreeHelper.GetChild(parent, childIndex);        
        if (childElement is FrameworkElement uiElement && uiElement.Name.Equals(
              childElementName,
              StringComparison.OrdinalIgnoreCase))
        {
          resultElement = uiElement;
          return true;
        }
        if (childElement.TryFindVisualChildElementByName(childElementName, out resultElement))
        {
          return true;
        }
      }
      return false;
    }
