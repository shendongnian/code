     public ObservableCollection<Order> Orders { get; private set; }
            ObservableCollection<Object> _SelectedRows;
            public ObservableCollection<Object> SelectedRows {
                get { return _SelectedRows; }
                set {
                    _SelectedRows.CollectionChanged -= OnSelectedRowsCollectionChanged;
                    _SelectedRows.Clear();
                    foreach (var item in value)
                        _SelectedRows.Add(item);
                    _SelectedRows.CollectionChanged += OnSelectedRowsCollectionChanged;
                }
            }
