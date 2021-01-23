	private string resultat(string s)
	{
		Runspace space = RunspaceFactory.CreateRunspace();
		space.Open();
		Pipeline pipeline = space.CreatePipeline();
		pipeline.Commands.AddScript(s);
		pipeline.Commands.Add("Out-String");
		Collection<PSObject> results = pipeline.Invoke();
		StringBuilder stringBuilder = new StringBuilder();
		foreach (PSObject obj in results)
		{
			stringBuilder.AppendLine(obj.ToString());
		}
		
		return stringBuilder.ToString();
	}
