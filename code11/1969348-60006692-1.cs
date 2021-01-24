	private string _SomeTextbox = "";
	public string SomeTextbox
	{
		get { return _SomeTextbox; }
		set
		{
			_SomeTextbox = value;
			OnPropertyChanged(new PropertyChangedEventArgs("SomeTextbox"));
			
			// Call method to check for possible suggestions.
			// Display Listbox with suggested items.
		}
	}
