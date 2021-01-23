	private int _MyProperty = 0;
	public int MyProperty
	{
		get { return _MyProperty; }
		set
		{
			if (_MyProperty != value)
			{
				_MyProperty = value;
				OnPropertyChanged("MyProperty");
			}
		}
	}
