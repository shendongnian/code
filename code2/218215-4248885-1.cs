    private void MenuItem_Check(MenuItem item)
    {
         if ((item.Visibility == Visibility.Hidden) || 
             (item.Visibility == Visibility.Collapsed))
         {
             item.Visibility = Visibility.Visible;
         }
    }
