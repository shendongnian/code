	private IEnumerable<HierarchyViewModel> _hierarchy = null;
	public IEnumerable<HierarchyViewModel> Hierarchy
	{
		get { return _hierarchy; }
		set
		{
			if (_hierarchy != value)
			{
				_hierarchy = value;
				NotifyPropertyChanged("Hierarchy");
			}
		}
	}
