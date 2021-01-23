        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count != 0)
            {
                var selectedItem = e.AddedItems[0];
                if (e.AddedItems[0] != _ViewModel.SelectedFormatType)
                {
                    var comboBoxSelectedItemBindiner = _TypesComboBox.GetBindingExpression(Selector.SelectedItemProperty); //_TypesComboBox is the name of the ComboBox control
                    if (_ViewModel.ConfirmChange(selectedItem))
                    {
                        // Update the VM.SelectedItem property if the user confirms the change.
                        comboBoxSelectedItemBindiner.UpdateSource();
                    }
                    else
                    {
                        //otherwise update the view in accordance to the VM.SelectedItem property 
                        comboBoxSelectedItemBindiner.UpdateTarget();
                    }
                }
            }
        }
