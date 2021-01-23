        private void iconSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {            
                try
                {
                    Properties.Settings.Default.iconHeight = Convert.ToInt32(iconSizeSlider.Value);
                    Properties.Settings.Default.iconWidth = Convert.ToInt32(iconSizeSlider.Value * 1.3);
                    Properties.Settings.Default.Save();
                    //iconWidth.Text = buttonWidth.ToString();
                    //ButtonRefresh();
                }
                catch (FormatException)
                {
                }
            
        }
