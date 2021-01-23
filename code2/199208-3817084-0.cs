    var viewModels = new ObservableCollection<ViewModelBase>(items.Select(CreateViewModelFromItem));
    private ViewModelBase CreateViewModelFromItem(Item item)
    {
        if (item is ItemType1) return new ViewModel1((ItemType1)item);
        if (item is ItemType2) return new ViewModel2((ItemType2)item);
        ...
        throw new ArgumentException("Unknown model type");
    }
