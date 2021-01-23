    public string Name
    {
        get { return name; }
        set { name = value; }
    }
	
	public static bool IsNameValid(string name) 
	{
		if (string.IsNullOrEmpty(name) || name.Length > 35)
		{
			return false;
		}
		
		foreach (char item in value)
		{                        
			if (!char.IsLetter(item))
			{
				return false;
			}
		}
		return true;
	}
	
