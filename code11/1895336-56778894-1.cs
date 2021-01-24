	public string AbilityTitle
	{
		get
		{
			return AbiltyTitleLabel.Text;
		}
		set
		{
			AbiltyTitleLabel.Text = value;
            //Raising the event!
			_onAbilityTitleChanged?.Invoke(this, new EventArgs());
		}
	}
