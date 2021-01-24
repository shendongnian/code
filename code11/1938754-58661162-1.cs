     private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadingWindow load = new LoadingWindow(...);
            Mouse.OverrideCursor = null;
            //Application.Current.MainWindow.Close();
            this.Close();
            load.ShowDialog();  //  Exception is here the next time it is called
        }
