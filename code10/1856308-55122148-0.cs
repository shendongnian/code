    public void ColorChanger(object sender, MouseButtonEventArgs e)
    {
        if (sender is TreeViewItem menuItem)
            this.Background = menuItem.Foreground;
    }
