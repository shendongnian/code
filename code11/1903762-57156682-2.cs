    public void CelebrateBirthday(DateTime birthday)
	{
		if (birthday.Date != DateTime.Today)
		{
			return;
		}
		
		GivePresent();
		GiveCard();
		TakeToLunch();
	}
	
