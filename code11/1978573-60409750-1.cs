    public void Update(DomainLayer.Models.Client.Client client)
	{
		if (client.ClientId == null)
		{
			throw new ApplicationException(msgType: MsgType.Error,
				"ClientID is null", "Applciation exception");
		}
		
		if (!_clientQuery.IsNameExistWithinClient(client.SectorId, (int)client.ClientId, client.Name) &&
			_clientQuery.IsNameExistWithinSector(client.SectorId, client.Name))
		{
			throw new ApplicationException(msgType: MsgType.Error,
					"Such client name already exist for that sector", "Applciation exception");
			
		}
		switch (client)
		{
			case BottleClient bottleClient:
				_bootleclientRepository.Update(bottleClient);
				break;
			case HatClient hatClient:
				_hatclientRepository.Update(hatClient);
				break;
		}			
	}
