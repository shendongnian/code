		private void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.OldItems != null)
			{
				foreach (object item in e.OldItems)
				{
					if (item is INotifyPropertyChanged npc)
						npc.PropertyChanged -= OnItemPropertyChanged;
				}
			}
			if (e.NewItems != null)
			{
				foreach (object item in e.NewItems)
				{
					if (item is INotifyPropertyChanged npc)
						npc.PropertyChanged += OnItemPropertyChanged;
				}
			}
