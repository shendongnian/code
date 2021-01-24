        private void cbTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
                {
                    ComboBox comboBox = new ComboBox();
                    if(sender is ComboBox)
                    {
                        comboBox = (ComboBox)sender;
                    }
    //Add the treatments you want
                    comboBox.Items.Clear();
                    comboBox.ItemsSource = listTest;
                    
                }
