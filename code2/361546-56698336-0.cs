    private object _SelectedItem;
    public object SelectedItem 
    {
        get { return _SelectedItem;}
        set {
               if(_SelectedItem == value)// avoid rechecking cause prompt msg
                { 
                   return;
                } 
                MessageBoxResult result = MessageBox.Show
                        ("Continue change?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {
                    ComboBox combo = (ComboBox)sender;
                    handleSelection = false;
                    combo.SelectedItem = e.RemovedItems[0];
                    return;
                }
                _SelectedItem = value;
                RaisePropertyChanged(); 
            }
    }
