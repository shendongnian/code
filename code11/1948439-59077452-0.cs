cs
            public string SelectedComboBoxItem
            {
                get
                {
                    return __SelectedComboBoxItem;
                }
                set
                {
                    if (_SelectedComboBoxItem != value)
                    {
                        _SelectedComboBoxItem = value;
                        RaisePropertyChanged(nameof(SelectedComboBoxItem));
                    }
                }
            }
            private string _SelectedComboBoxItem = string.Empty;
and update your binding according that
SelectedItem="{Binding SelectedComboBoxItem, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
