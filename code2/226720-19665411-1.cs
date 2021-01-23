    private void myListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        DependencyObject obj = (DependencyObject)e.OriginalSource;
        while (obj != null && obj != myListBox)
        {
            if (obj.GetType() == typeof(ListBoxItem))
            {
                 // Do something
                 break;
             }
             obj = VisualTreeHelper.GetParent(obj);
        }
    }
