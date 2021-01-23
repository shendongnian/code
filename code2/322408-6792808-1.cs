    public ObservableCollection<object> MyCollectionProperty { get; set; }
    public void SetValues(IEnumerable<object> values)
    {
          MyCollectionProperty = new ObservableCollection<object>();
          foreach (var item in values)
          {
              var addingItem=item;
              Dispatcher.BeginInvoke(() => MyCollectionProperty.Add(addingItem));
          }
    }
