	public void AddCssClass(string value)
	{
		string currentValue;
		if (Attributes.TryGetValue("class", out currentValue))
		{
			Attributes["class"] = value + " " + currentValue;
		}
		else
		{
			Attributes["class"] = value;
		}
	}
