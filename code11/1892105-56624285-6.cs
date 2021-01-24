	private int _boundNumber2;
	public int BoundNumber2
	{
		get { return _boundNumber2; }
		set
		{
			if (_boundNumber2 != value)
			{
				_boundNumber2 = value;
				OnPropertyChanged();
				QuickMath = BoundNumber + BoundNumber2;
			}
		}
	}
