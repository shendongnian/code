    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        this.Left = Properties.Settings.Default.LocationX;
        this.Top = Properties.Settings.Default.LocationY;
        this.Width = Properties.Settings.Default.WindowWith;
        this.Height = Properties.Settings.Default.WindowHeight;
    }
    void MainWindow_Closed(object sender, EventArgs e)
    {
        Properties.Settings.Default.LocationX = this.Left;
        Properties.Settings.Default.LocationY = this.Top;
        Properties.Settings.Default.WindowWith = this.Width;
        Properties.Settings.Default.WindowHeight = this.Height;
        Properties.Settings.Default.Save();
    }
