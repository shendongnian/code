     private void Window_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.LeftAlt || e.Key == Key.RightAlt)
                {
                    myMenu.Visibility = Visibility.Visible;
                }
            }
