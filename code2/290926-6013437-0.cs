    /// <summary>
    /// Occurrs when an item is selected in the form
	/// </summary>
    public event EventHandler<ItemSelectedEventArgs> ItemSelected;
	
    /// <summary>
    /// Fires the <see cref="ItemSelected" /> event
	/// </summary>
	protected void OnItemSelected(MyItem item) 
    {
	    var handler = this.ItemSelected;
		if (handler != null)
		{
		    ItemSelectedEventArgs args = new ItemSelectedEventArgs();
			args.Item = item; // For example
			handler(this, args);
		}
	}
	
