    private void dgFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            System.Diagnostics.Debug.WriteLine("dgFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)");
        }
    }
    private void dgLines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("dgLines_MouseDoubleClick(object sender, MouseButtonEventArgs e)");
        e.Handled = true;
    }
