	foreach (var dbObject in dbObjects)
	{
		switch (dbObject)
		{
			case Database db:
                _webApi.DeleteObject<Database>(db.id);
				break;
			
			case Table tbl:
                _webApi.DeleteObject<Table>(tbl.id);
				break;
				
			default:
				throw new Exception("Someone added a weird object to the collection...");
		}
	}
