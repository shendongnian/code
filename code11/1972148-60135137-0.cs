    private void Button_Click(object sender, RoutedEventArgs e)
        {
          this.PreviewMouseLeftButtonDown += MainWindow_PreviewMouseLeftButtonDown;
        }
    
     private void MainWindow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           this.PreviewMouseLeftButtonDown -= MainWindow_PreviewMouseLeftButtonDown;
           Point point = e.GetPosition(this);
           MessageBox.Show(point.ToString());
           e.Handled = true;
        }
