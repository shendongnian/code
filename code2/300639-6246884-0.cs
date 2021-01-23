	private MyDelegate _MyEvent;
	public MyDelegate MyEvent
	{
		add
		{
			_MyEvent += value;
		}
		remove
		{
			_MyEvent -= value;
		}
	}
