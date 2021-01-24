    <AutoSuggestBox Text="{x:Bind SearchText, Mode=TwoWay}"> 
    private string searchText;
    
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        if (PropertyChanged != null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public string SearchText
    {
    
        get { return searchText; }
        set
        {
            _passWord = value;
            this.ViewModel.RefreshAddressSuggestions(value);
            OnPropertyChanged();
    
          
        }
    }
