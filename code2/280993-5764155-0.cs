	// Open the container once for the life-time of your application
	IObjectConainer rootContainer = Db4oEmbedded.OpenFile(......)
	public IList<T> GetList<T>()
	{
		using (IObjectContainer db = rootContainer.Ext().OpenSession())
		{
                        // As Femaref said, use to list to 'eagerly' load all data
			return db.Query<T>(typeof(T)).ToList();
		}
	}
