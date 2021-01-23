    public sealed class ItemObservableCollection<T> : ObservableCollection<T>
    	where T : INotifyPropertyChanged
    {
    	public event EventHandler<ItemPropertyChangedEventArgs<T>> ItemPropertyChanged;
    
    	protected override void InsertItem(int index, T item)
    	{
    		base.InsertItem(index, item);
    		item.PropertyChanged += item_PropertyChanged;
    	}
    
    	protected override void RemoveItem(int index)
    	{
    		var item= this[index];
    		base.RemoveItem(index);
    		item.PropertyChanged -= item_PropertyChanged;
    	}
    
    	protected override void ClearItems()
    	{
    		foreach (var item in this)
    		{
    			item.PropertyChanged -= item_PropertyChanged;
    		}
    
    		base.ClearItems();
    	}
    
    	protected override void SetItem(int index, T item)
    	{
    		var oldItem = this[index];
    		oldItem.PropertyChanged -= item_PropertyChanged;
    		base.SetItem(index, item);
    		item.PropertyChanged += item_PropertyChanged;
    	}
    
    	private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    	{
    		OnItemPropertyChanged((T)sender, e.PropertyName);
    	}
    
    	private void OnItemPropertyChanged(T item, string propertyName)
    	{
            var handler = this.ItemPropertyChanged;
            if (handler != null)
            {
                 handler(this, new ItemPropertyChangedEventArgs<T>(item, propertyName));
            }
    	}
    }
    public sealed class ItemPropertyChangedEventArgs<T> : EventArgs
    {
        private readonly T _item;
        private readonly string _propertyName;
        public ItemPropertyChangedEventArgs(T item, string propertyName)
        {
            _item = item;
            _propertyName = propertyName;
        }
        public T Item
        {
            get { return _item; }
        }
        public string PropertyName
        {
            get { return _propertyName; }
        }
    }
