	public event EventHandler AbilityTitleChanged
	{
		add
		{
			_onAbilityTitleChanged += value;
		}
		remove
		{
			_onAbilityTitleChanged -= value;
		}
	}
