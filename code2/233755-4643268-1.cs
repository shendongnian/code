	protected override PageStatePersister PageStatePersister
	{
		get
		{
			return new SessionPageStatePersister(this);
		}
	}
