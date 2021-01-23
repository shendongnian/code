            var p = new Dapper.Tvp.DynamicParametersTvp();
            SqlMetaData[] tableValuedParameterDefinition = 
            { 
                new SqlMetaData("columnOne", SqlDbType.UniqueIdentifier), 
                new SqlMetaData("columnTwo", SqlDbType.VarBinary, 64)
            };
            var collectionRows = new List<SqlDataRecord>();
            for (int i = 0; i < collection.Count; i++)
            {
                var row = new SqlDataRecord(tableValuedParameterDefinition);
                row.SetGuid(0, collection[i].Item1);
                row.SetBytes(1, 0, collection[i].Item2, 0, sessionsAndPins[i].Item2.Length);
                collectionRows.Add(row);
            }
            p.Add(new Dapper.Tvp.TableValueParameter("@tvpName", "tvpTypeName", collectionRows));
            using (SqlConnection connection = new SqlConnection(ConnectionManager.GetConnectionString("Database")))
            {
                try
                {
                    connection.Open();
                    result = connection.Query<SomeObject>("SomeStoredProcedureThatExpectsTVP", p, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
                finally
                {
                    connection.Close();
                }
            }
