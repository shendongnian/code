    using (var tbl = new DataTable())
	{
        // disable table load events
		tbl.BeginLoadData();
		try
		{
            // only load schema in the first place
			tbl.Load(cmd.ExecuteReader(CommandBehavior.SchemaOnly));
            // clear all constraints capable of raising exceptions
			tbl.Constraints.Clear();
            // reload table with data (schema is not reloaded!)
			tbl.Load(cmd.ExecuteReader());
		}
		finally
		{
			tbl.EndLoadData();
		}
	}
