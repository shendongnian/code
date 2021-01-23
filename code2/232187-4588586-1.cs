    public ObservableCollection<Item> Names { get; set; }
    public List<Item> ModifiedItems { get; set; }
    
    public ViewModel()
    {
       this.ModifiedItems = new List<Item>();
       this.Names = new ObservableCollection<Item>();
       this.Names.CollectionChanged += this.OnCollectionChanged;
    }
    
    void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
       foreach(Item newItem in e.NewItems)
       {
           ModifiedItems.Add(newItem);
 
           //Add listener for each item on PropertyChanged event
           item.PropertyChanged += this.OnItemPropertyChanged;         
       }
    
       foreach(string oldItem in e.OldItems)
       {
           ModifiedItems.Add(oldItem);
           
           item.PropertyChanged -= this.OnItemPropertyChanged;
       }
    }
    void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        Item item = sender as Item;
        if(item != null)
           ModifiedItems.Add(item);
    }
