	public void SomeMethode()
	{
		if (ConnectionIsOpen())
		{
			m_Service.Dummy();
			// Connection is lost here
			m_Service.SomeMethode();
		}
	}
