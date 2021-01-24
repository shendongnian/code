    public void male_Click(object sender, RoutedEventArgs e)
            {
               
            
                System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                img.Source = new BitmapImage(new Uri(@"pack://application:,,,/maindocket;component/Imagesrc/logotype/USER_MALE_SELECTED.png"));
                male.Content = img;
    }
