	public Visibility MachinesColumnVisible
	{
		get { return MachinesColumn.Visibility; }
		set
		{
			if (value == MachinesColumn.Visibility)
				return;
			MachinesColumn.Visibility = value;
		}
	}
