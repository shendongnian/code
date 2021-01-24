        private void Click_big(object sender, MouseButtonEventArgs e)
        {
          btn_big.Visibility=Visibility.Hidden;
          btn_small1.Visibility=Visibility.Visible;
          btn_small2.Visibility=Visibility.Visible;          
        }
        private void Click_small(object sender, MouseButtonEventArgs e)
        {
          btn_big.Visibility=Visibility.Visible;
          btn_small1.Visibility=Visibility.Hidden;
          btn_small2.Visibility=Visibility.Hidden;          
        }
