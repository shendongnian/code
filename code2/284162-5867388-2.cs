	Person person = new Person() { FirstName = "Charles", LastName = "The Second" };
	Db4oUUID uuid;
	using (IObjectContainer client = server.OpenClient())
	{
		// Store the new object for the first time
		client.Store(person);
		// Keep the UUID for later use
		uuid = client.Ext().GetObjectInfo(person).GetUUID();
	}
	// Guy changed his name, it happens
	person.FirstName = "Lil' Charlie";
	using (var client = server.OpenClient())
	{
		// Get a reference only (not data) to the stored object (server round trip, but lightweight)
		Person inactiveReference = (Person) client.Ext().GetByUUID(uuid);
		// Get the temp ID for this object within this client session
		long tempID = client.Ext().GetID(inactiveReference);
		// Replace the object the temp ID points to
		client.Ext().Bind(person, tempID);
		// Replace the stored object
		client.Store(person);
	}
