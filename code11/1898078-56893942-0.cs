	private static Poolable _instance;
	private static object _instanceLock = new Object();
	public static Poolable Instance
	{
		get
		{
			if (_instance == null)
			{
				lock (_instanceLock)
				{
					if (_instance == null)
					{
						this._instance = [Whatever way you instantiate it];
					}
				}
			}
			return _instance;
		}
		
	}
