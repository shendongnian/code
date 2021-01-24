    private ObservableCollection<ItemGroup> _itemGroups;
    public ObservableCollection<ItemGroup> ItemGroups
    {
    	get => _itemGroups;
    	set => SetProperty(ref _itemGroups, value);
    }
    
    private Item _selectedItem;
    public Item SelectedItem
    {
    	get => _selectedItem;
    	set => SetProperty(ref _selectedItem, value);
    }
    
    private ICommand _itemTappedCommand;
    public ICommand ItemTappedCommand => _itemTappedCommand ?? (_itemTappedCommand = new Command<Item>((item) =>
    {
    	SelectedItem = item;
    }));
