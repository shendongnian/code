    foreach (UIElement childElement in myUIElementCollection) 
    {
      for (int i = 0; i < VisualTreeHelper.GetChildrenCount(childElement); i++)
      {
         DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
         var checkBox = child as CheckBox;
         if (checkBox != null)
         {
             // update it
         }
      }
    }
