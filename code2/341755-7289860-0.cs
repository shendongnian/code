    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button btn = sender as Button;
    
        StackPanel sp1 = VisualTreeHelper.GetParent(btn) as StackPanel;
        StackPanel sp2 = VisualTreeHelper.GetParent(sp1) as StackPanel;
    
        StackPanel phone = sp2.FindName("PhoneNumber") as StackPanel;
    
        if (phone.Visibility == System.Windows.Visibility.Collapsed)
            phone.Visibility = System.Windows.Visibility.Visible; 
        else
            phone.Visibility = System.Windows.Visibility.Collapsed;
        DependencyObject dpObject = btn;
        while (dpObject != null)
        {
            if (dpObject is UIElement)
            {
                (dpObject as UIElement).InvalidateMeasure();
            }
            dpObject = VisualTreeHelper.GetParent(dpObject);
        }
    }
