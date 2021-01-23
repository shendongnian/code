    public class BindableListView : ListView
    {
        private const string DataCategoryName = "Data";
        private INotifyCollectionChanged _collection;
        [Category(DataCategoryName)]
        public INotifyCollectionChanged Collection
        {
            get { return _collection; }
            set
            {
                if (_collection != null) _collection.CollectionChanged -= CollectionChanged;
                _collection = value;
                BindObject(_collection);
                if (_collection != null) _collection.CollectionChanged += CollectionChanged;
            }
        }
        private const bool DefaultDefaultBrowsableState= false;
        [Category(DataCategoryName)]
        [DefaultValue(DefaultDefaultBrowsableState)]
        public bool DefaultBrowsableState { get; set; } = DefaultDefaultBrowsableState;
        private void BindObject(object obj)
        {
            Clear();
            if (obj != null)
            {
                Columns.AddRange(obj.GetType().GetGenericArguments().FirstOrDefault()?.GetProperties().Where(p =>
                {
                    return p.GetCustomAttributes(true).OfType<BrowsableAttribute>().FirstOrDefault()?.Browsable ?? DefaultBrowsableState;
                }).Select(p =>
                {
                    return new ColumnHeader()
                    {
                        Name = p.Name,
                        Text = p.GetCustomAttributes(true).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? p.Name
                    };
                }).ToArray());
                AddItems(obj as System.Collections.IEnumerable);
            }
        }
        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddItems(e.NewItems);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var oldItem in e.OldItems)
                    {
                        if (Items.OfType<ListViewItem>().FirstOrDefault(item => Equals(item.Tag, oldItem)) is ListViewItem itemToRemove)
                        {
                            UnregisterItem(oldItem);
                            Items.Remove(itemToRemove);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (e.OldItems.Count == e.NewItems.Count)
                    {
                        var count = e.OldItems.Count;
                        for (var i = 0; i < count; i++)
                        {
                            var itemPair = new { Old = e.OldItems[i], New = e.NewItems[i] };
                            if (Items.OfType<ListViewItem>().FirstOrDefault(item => Equals(item.Tag, itemPair.Old)) is ListViewItem itemToReplace)
                            {
                                UnregisterItem(itemPair.Old);
                                RegisterItem(itemPair.New);
                                itemToReplace.Tag = itemPair.New;
                                foreach (ColumnHeader column in Columns)
                                {
                                    itemToReplace.SubItems[column.Index].Text = itemPair.New.GetType().GetProperty(column.Name).GetValue(itemToReplace)?.ToString();
                                }
                            }
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    foreach (var oldItem in e.OldItems)
                    {
                        if (Items.OfType<ListViewItem>().FirstOrDefault(item => Equals(item.Tag, oldItem)) is ListViewItem itemToMove)
                        {
                            Items.Remove(itemToMove);
                            Items.Insert(e.NewStartingIndex, itemToMove);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Items.Clear();
                    break;
                default:
                    break;
            }
            AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void AddItems(System.Collections.IEnumerable items)
        {
            Items.AddRange((items ?? Enumerable.Empty<object>()).OfType<object>().Select(item =>
            {
                RegisterItem(item);
                return new ListViewItem(Columns.OfType<ColumnHeader>().Select(column =>
                {
                    return item.GetType().GetProperty(column.Name).GetValue(item)?.ToString() ?? "";
                }).ToArray())
                {
                    Tag = item
                };
            }).ToArray());
        }
        private void RegisterItem(object item)
        {
            if(item is INotifyPropertyChanged observableItem) observableItem.PropertyChanged += ObservableItem_PropertyChanged;
        }
        private void UnregisterItem(object item)
        {
            if (item is INotifyPropertyChanged observableItem) observableItem.PropertyChanged -= ObservableItem_PropertyChanged;
        }
        private void ObservableItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Items.OfType<ListViewItem>().FirstOrDefault(itm => Equals(itm.Tag, sender)) is ListViewItem item)
            {
                item.SubItems[Columns[e.PropertyName].Index].Text = sender.GetType().GetProperty(e.PropertyName).GetValue(sender)?.ToString();
            }
        }
    }
