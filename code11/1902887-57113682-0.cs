    public Car Car1
	{
		get
		{
			if(_car == null)
				_car = new Car();
			return _car;
		}
		set
		{
			_car = value;
		}
	}
