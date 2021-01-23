	string name;
	public string Name 
	{
		get
		{
			return name;
		}
		set
		{
			string oldValue = Name;
			name = value;
			NotificationAmender<ConcreteClass>.OnPropertyChanged<string>(
				this, "Name", oldValue, value, Name);
		}
	}
