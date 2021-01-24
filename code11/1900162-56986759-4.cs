    private ICommand addItemCommand;
    public ICommand AddItemCommand
    {
    	get { return addItemCommand ?? (addItemCommand = new RelayCommand(AddItem)); }
    }
    
    private void AddItem(object obj)
    {
    	Items.Add(new MyItem());
    }
