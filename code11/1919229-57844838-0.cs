    public static bool TryFindVisualChildElementByName(
      this DependencyObject parent,
      string childElementName,
      out FrameworkElement resultElement)
    {
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
        if (childElement is Popup popup)
        {
          childElement = popup.Child;
        }
        if (childElement.TryFindVisualChildElementByName(childElementName, out resultElement))
        {
          return true;
        }
      }
      return false;
    }
