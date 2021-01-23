    private void listBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        var item = ItemsControl.ContainerFromElement(listBox, e.OriginalSource as DependencyObject) as ListBoxItem;
        if (item != null)
        {
            // ListBox item clicked - do some cool things here
        }
    }
