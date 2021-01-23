    private void Grid_MouseEnter(object sender, MouseEventArgs e)
    {
        OverlayImage.Visibility = System.Windows.Visibility.Visible;
    }
    
    private void Grid_MouseLeave(object sender, MouseEventArgs e)
    {
        OverlayImage.Visibility = System.Windows.Visibility.Collapsed;
    }
