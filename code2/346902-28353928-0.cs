    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
    if (e.ChangedButton == MouseButton.Left)
        this.DragMove();
    }
