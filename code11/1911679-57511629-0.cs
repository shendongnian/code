    var sql = "begin CreateTodo(Item => :p0, Done => :p1, DateStamp => :p2); end;";
    var entityType = _dbContext.Model.FindEntityType(typeof(TodoEFCoreModel));
    var dbCommand = _dbContext.Database.GetDbConnection().CreateCommand();
    object[] parameters =
    {
    	entityType.FindProperty("Item").FindRelationalMapping()
    		.CreateParameter(dbCommand, "p0", databaseTodoEntity.Item),
    	entityType.FindProperty("Done").FindRelationalMapping()
    		.CreateParameter(dbCommand, "p1", databaseTodoEntity.Done),
    	entityType.FindProperty("DateStamp").FindRelationalMapping()
    		.CreateParameter(dbCommand, "p2", databaseTodoEntity.DateStamp),
    };
    await _dbContext.Database.ExecuteSqlCommandAsync(sql, parameters);
