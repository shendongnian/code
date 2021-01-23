	private InfostoreBase myConnectionSource;
	private void Initialize()
	{
		// ...
		myConnectionSource = 
			InfostoreProvider.GetConnection(
				myKey, isEnterprise, myData
			);
		//...
	}
