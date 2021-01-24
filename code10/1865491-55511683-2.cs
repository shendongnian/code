    string _selectedItem;
    public string SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsItemSelected));
        }
    }
    public bool IsItemSelected => SelectedItem != null;
