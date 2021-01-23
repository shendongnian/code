            var schema = new DbSchema(ConnectionString, DbPlatform.SqlServer2014);
            schema.Alter(db => db.CreateTable(TName)
               .WithPrimaryKeyColumn("Id", DbType.Int32).AsIdentity()
               .WithNotNullableColumn("DateTime", DbType.Date)
               ...);
