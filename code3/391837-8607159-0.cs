    class RangeEnabledObservableCollection<T> : ObservableCollection<T>
    {
    	public void InsertRange(IEnumerable<T> items) 
    	{
    		this.CheckReentrancy();
    		foreach(var item in items)
    			this.Items.Add(item);
    		this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    	}
    }
