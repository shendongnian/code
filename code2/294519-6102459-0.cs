	private List<string> GetMyCurrentEndpoints()
	{
		var endpointList = new List<string>();
		var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		var serviceModel = ServiceModelSectionGroup.GetSectionGroup(config);
		foreach (ChannelEndpointElement endpoint in serviceModel.Client.Endpoints)
		{
			endpointList.Add(endpoint.Address.ToString());
		}
		return endpointList;
	}
