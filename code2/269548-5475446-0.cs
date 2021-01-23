	foreach (EndpointDispatcher epDisp in chDisp.Endpoints)
	{
		epDisp.DispatchRuntime.MessageInspectors.Add(this);
		foreach (DispatchOperation op in epDisp.DispatchRuntime.Operations)
		{
			op.ParameterInspectors.Add(this); // JUST AS AN EXAMPLE 
		}                        
	}
