    private void MenuItem_Check(item.Visibility)
    {
         if ((item.Visibility == Visibility.Hidden) || 
             (item.Visibility == Visibility.Collapsed))
         {
             item.Visibility = Visibility.Visible;
         }
    }
