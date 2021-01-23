	class MyCollection : List<IDisplayable>
	{
		public bool containsHumans()
		{
			foreach (IDisplayable item in this)
			{
				if (item is Human)
					return true;
			}
			return false;
		}
		// likewise for containsAnimals(), etc
	}
	public string Summarize()
	{
		MyCollection displayableItems = getAllDisplayableItems();
		StringBuilder summary = new StringBuilder();
		if (displayableItems.containsHumans() && !displayableItems.containsAnimals())
		{
			// do human-only logic here
		}
		else if (!displayableItems.containsHumans() && displayableItems.containsAnimals())
		{
			// do animal-only logic here
		}
		else
		{
			// do logic for both here
		}
		return summary.ToString();
	}
