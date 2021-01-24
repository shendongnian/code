     private void ToggleButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (yourToggleButton.IsChecked == true)
            {
                //uncheck task
                yourToggleButton.IsChecked = false;
                
            }
            else
            {
                //check task
                yourToggleButton.IsChecked = true;
            }
        }
