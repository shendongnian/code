    public static class Extensions
    { 
      /// <summary>
      /// Traverses the visual tree towards the leafs until an element with a matching element type is found.
      /// </summary>
      /// <typeparam name="TChild">The type the visual child must match.</typeparam>
      /// <param name="parent"></param>
      /// <param name="resultElement"></param>
      /// <returns></returns>
      public static bool TryFindVisualChildElement<TChild>(this DependencyObject parent, out TChild resultElement)
        where TChild : DependencyObject
      {
        resultElement = null;
        if (parent is Popup popup)
        {
          parent = popup.Child;
          if (parent == null)
          {
            return false;
          }
        }
        for (var childIndex = 0; childIndex < VisualTreeHelper.GetChildrenCount(parent); childIndex++)
        {
          DependencyObject childElement = VisualTreeHelper.GetChild(parent, childIndex);
          if (childElement is TChild child)
          {
            resultElement = child;
            return true;
          }
          if (childElement.TryFindVisualChildElement(out resultElement))
          {
            return true;
          }
        }
        return false;
      }
    }
