    public static class Extensions
    {
      /// <summary>
      /// Traverses the visual tree towards the root until an element with a matching element name is found.
      /// </summary>
      /// <typeparam name="TParent">The type the visual parent must match.</typeparam>
      /// <param name="child"></param>
      /// <param name="resultElement"></param>
      /// <returns></returns>
      public static bool TryFindVisualParentElement<TParent>(this DependencyObject child, out TParent resultElement)
        where TParent : DependencyObject
      {
        resultElement = null;
    
        DependencyObject parentElement = VisualTreeHelper.GetParent(child);
    
        if (parentElement is TParent parent)
        {
          resultElement = parent;
          return true;
        }
    
        return parentElement?.TryFindVisualParentElement(out resultElement) ?? false;
      }
    }
