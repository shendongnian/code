    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
       this.Show();
       this.Invalidate();
       while (!AppMain.needClose)
       {
          System.Windows.Forms.Application.DoEvents();
          DoThings();
       }
    }
