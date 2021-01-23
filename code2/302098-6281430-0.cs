	ExecuteIgnoringExceptions(() => textBox.Text = Some.Possibly.Bad.Value);
	void ExecuteIgnoringExceptions(Action a) 
	{
		try
		{
			a.Invoke();
		}
		catch
		{
		}
	}
