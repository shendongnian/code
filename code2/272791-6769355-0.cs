    public override SyncSchema GetSchema(Collection<string> tableNames,SyncSession syncSession)
    {
      var schema = base.GetSchema(tableNames,syncSession);
      schema.SchemaDataSet.Tables["Table1"].Constraints.Add(new ForeignKeyConstraint(...));
      return schema;
    }
