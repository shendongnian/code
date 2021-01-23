        if (sender is ObservableCollection<PromotionPurchaseAmount> || 
            sender is ObservableCollection<PromotionItemPricing> || 
            sender is ObservableCollection<PromotionItem>)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove ||
                e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (INotifyPropertyChanged item in e.OldItems)
                {
                    //Removed items
                    item.PropertyChanged -= EntityViewModelPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add ||
                     e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (INotifyPropertyChanged item in e.NewItems)
                {
                    //Added items
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
        }
