        public class ObservableCollectionExt<T> : ObservableCollection<T>
        {
            public override event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged;
    
            protected override void SetItem(int index, T item)
            {
                base.SetItem(index, item);
    
                if(item is INotifyPropertyChanged)
                    (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);
            }
    
            protected override void ClearItems()
            {
                for (int i = 0; i < this.Items.Count; i++)
                    DeRegisterINotifyPropertyChanged(this.IndexOf(this.Items[i]));
    
                base.ClearItems();
            }
    
            protected override void InsertItem(int index, T item)
            {
                base.InsertItem(index, item);
                RegisterINotifyPropertyChanged(item);
            }
    
            protected override void RemoveItem(int index)
            {
                base.RemoveItem(index);
                DeRegisterINotifyPropertyChanged(index);
            }
    
            private void RegisterINotifyPropertyChanged(T item)
            {
                if (item is INotifyPropertyChanged)
                    (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);
            }
    
            private void DeRegisterINotifyPropertyChanged(int index)
            {
                if (this.Items[index] is INotifyPropertyChanged)
                    (this.Items[index] as INotifyPropertyChanged).PropertyChanged -= OnPropertyChanged;
            }
    
            private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                T item = (T)sender;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, item)); 
            }
        }
