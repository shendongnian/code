    public class ObservableCollectionEnhanced<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
      public ObservableCollectionEnhanced()
        : base()
      { }
    
      public ObservableCollectionEnhanced(IEnumerable<T> collection)
        : base(collection)
      {
        foreach (T item in Items)
          item.PropertyChanged += OnItemPropertyChanged;
      }
    
      public ObservableCollectionEnhanced(List<T> list)
        : base(list)
      {
        foreach (T item in Items)
          item.PropertyChanged += OnItemPropertyChanged;
      }
    
      public event System.ComponentModel.PropertyChangedEventHandler ItemPropertyChanged;
      public void OnItemPropertyChanged(Object sender, PropertyChangedEventArgs e)
      {
        if (null != ItemPropertyChanged)
          ItemPropertyChanged(sender, e);
      }
    
      protected override void InsertItem(int index, T item)
      {
        base.InsertItem(index, item);
        item.PropertyChanged += OnItemPropertyChanged;
      }
    
      protected override void RemoveItem(int index)
      {
        T item = this.Items[index];
        item.PropertyChanged -= OnItemPropertyChanged;
        base.RemoveItem(index);
      }
    
      protected override void SetItem(int index, T item)
      {
        T oldItem = Items[index];
        base.SetItem(index, item);
        oldItem.PropertyChanged -= OnItemPropertyChanged;
        item.PropertyChanged += OnItemPropertyChanged;
      }
    }
