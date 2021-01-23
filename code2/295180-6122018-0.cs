    public ObservableCollection<object> SelectedItems//init collection just ONCE!
        {
            get
            {
                if (this.selectedItems == null)
                {
                    this.selectedItems = new ObservableCollection<object>();
                    this.selectedItems.CollectionChanged +=
                        new System.Collections.Specialized.NotifyCollectionChangedEventHandler(SelectedItemsCollectionChanged);
                }
                return this.selectedItems;
            }
        }
        private void SelectedItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //this is called when ever the selecteditems changed
        }
