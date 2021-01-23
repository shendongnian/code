	public ObservableCollection<MyObject> Entries { get; set; }
	public CollectionViewSource View { get; set; }
	private string _searchText;
	public string SearchText
	{
		get { return _searchText; }
		set
		{
			if (_searchText == value)
				return;
			_searchText = value;
			View.Filter -= ApplySearch;
			if (!string.IsNullOrWhiteSpace(_searchText))
				View.Filter += ApplySearch;
		}
	}
	public MyClass()
	{
		Entries = new ObservableCollection<MyObject>();
		View = new CollectionViewSource { Source = Entries };
	}
  
	private void ApplySearch(object sender, FilterEventArgs e)
	{
			var item = e.Item as MyObject;
			if (item == null)
				return;
			if (item.FirstProperty.IndexOf(SearchText) < 0 && item.SecondProperty.IndexOf(SearchText) < 0)
				e.Accepted = false;
	}
