    /// <summary>
    ///   Returns the first ancestor of specified type
    /// </summary>
    public static T FindAncestor<T>(DependencyObject current) where T : DependencyObject {
      current = GetVisualOrLogicalParent(current);
    
      while (current != null) {
        if (current is T) {
          return (T)current;
        }
        current = GetVisualOrLogicalParent(current);
      }
    
      return null;
    }
    
    private static DependencyObject GetVisualOrLogicalParent(DependencyObject obj) {
      if (obj is Visual || obj is Visual3D) {
        return VisualTreeHelper.GetParent(obj);
      }
      return LogicalTreeHelper.GetParent(obj);
    }
