	private int _boundNumber;
	public int BoundNumber
	{
		get { return _boundNumber; }
		set
		{
			if (_boundNumber != value)
			{
				_boundNumber = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(QuickMath));
			}
		}
	}
