        private void BrightnessMenuClick(object sender, RoutedEventArgs e)
                    {
                        
                        if (LastBrightnessMenuItem != null)
                        {
                            LastBrightnessMenuItem.IsChecked = false;
                        }
                        
                        MenuItem m = sender as MenuItem;
                        LastBrightnessMenuItem = m;
            
                        //Handle the rest of the logic here
            
            
                    }
