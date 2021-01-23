	using( IDbCommand dbCommand = dbConnection.CreateCommand() )
	{
		dbCommand.CommandText = Properties.Settings.Default.UpdateCommand;
		Dictionary<string,object> values = new Dictionary<string,object>()
		{
			{"@param1",this.Property1},
			{"@param2",this.Property2},
			// ...
		};
		foreach( var item in values )
		{
			var p = dbCommand.CreateParameter();
			p.ParameterName = item.Key;
			p.Value = item.Value;
			dbCommand.Parameters.Add(p);
		}
	}
