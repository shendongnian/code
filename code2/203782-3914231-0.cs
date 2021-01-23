	public IEnumerable<Thingamajig> GetThingamajigs()
	{
		foreach (var thingamajigLocator in thingamajigLocators)
		{
			Thingamajig thingamajig;
			try
			{
				thingamajig = thingamajigservice.GetThingamajig(thingamajigLocator);
			}
			catch
			{
				// exception logged higher up
				// (how can this be? it just got swallowed right here)
				continue;
			}
			yield return thingamajig;
	
		}
	}
