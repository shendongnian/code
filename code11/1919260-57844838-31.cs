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
    }
