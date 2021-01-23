    private int previousSelection = 0; //Give it a default selection value
    private bool promptUser true; //to be replaced with your own property which will indicates whether you want to show the messagebox or not.
    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                ComboBox comboBox = (ComboBox) sender;
                BindingExpression be = comboBox.GetBindingExpression(ComboBox.SelectedValueProperty);
                if (comboBox.SelectedValue != null && comboBox.SelectedIndex != previousSelection)
                {
                    if (promptUser) //if you want to show the messagebox..
                    {
                        string msg = "Click Yes to leave previous selection, click No to stay with your selection.";
                        if (MessageBox.Show(msg, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) //User want to go with the newest selection
                        {
                            be.UpdateSource(); //Update the property,so your ViewModel will continue to do something
                            previousSelection = (int)comboBox.SelectedIndex;  
                        }
                        else //User have clicked No to cancel the selection
                        {
                            comboBox.SelectedIndex = previousSelection; //roll back the combobox's selection to previous one
                        }
                    }
                    else //if don't want to show the messagebox, then you just have to update the property as normal.
                    {
                        be.UpdateSource();
                        previousSelection = (int)comboBox.SelectedIndex;
                    }
                }
            }
