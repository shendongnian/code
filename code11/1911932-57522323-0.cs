     public async Task<List<string>> GetColumnsFromSQLStatement(string sqlStatement)
        {
            List<string> Columns = new List<string>();
            using (var con = SourceDatabaseConnectionFactory.GetConnection())
            {
                using (var dbTrans = SourceTransactionFactory.CreateTransaction(con, TransactionOptions.ReadOnly))
                {
                    DynamicParameters para = new DynamicParameters();
                    var tmp = con.ExecuteReader(sqlStatement, para, dbTrans, 100, CommandType.Text);
                    var schema = tmp.GetSchemaTable();
                    for (var i = 0; i < schema.Rows.Count; i++)
                    {
                        Columns.Add(schema.Rows[i]["columnName"].ToString());
                    }
                    dbTrans.Commit();
                }
            }
       
            return Columns;
        }
