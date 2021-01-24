    public static class HelperExtensions
    {
      public static bool TryFindVisualParentElement<TParent>(this DependencyObject child, out TParent resultElement)
        where TParent : DependencyObject
      {
        resultElement = null;
    
        if (child == null)
        {
          return false;
        }
    
        DependencyObject parentElement = VisualTreeHelper.GetParent(child);
    
        if (parentElement is TParent parent)
        {
          resultElement = parent;
          return true;
        }
    
        return parentElement.TryFindVisualParentElement(out resultElement);
      }
      public static bool TryFindVisualParentElementByName(
          this DependencyObject child,
          string elementName,
          out FrameworkElement resultElement)
        {
          resultElement = null;
          if (child == null)
          {
            return false;
          }
          DependencyObject parentElement = VisualTreeHelper.GetParent(child);
          if (parentElement is FrameworkElement frameworkElement &&
              frameworkElement.Name.Equals(elementName, StringComparison.OrdinalIgnoreCase))
          {
            resultElement = frameworkElement;
            return true;
          }
          return parentElement.TryFindVisualParentElementByName(elementName, out resultElement);
        }
      }
    }
