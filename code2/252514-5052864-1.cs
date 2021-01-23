    // XAML
    <DataGrid ...SomeCode... SelectedItem="{Binding SelectedItem}"/>
    // Inside my ViewModel I have:
    private object _SelectedItem;
    public object SelectedItem
    {
        get { return this._SelectedItem; }
        set
        {
            if (value != null)
            {
                this._SelectedItem = value;
                OnPropertyChanged(new PropertyChangedEventArgs(SelectedItemProperty));
            }
        }
    }
    // To resolve the SelectedItem you can use the following
    var item = (MyNamespace.MyDataSource)SelectedItem;
