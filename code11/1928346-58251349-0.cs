     public IEnumerable<TableChange> GetTableLastChanges(string tableName, string keyColumn, out int synchronizationVersion)
        {
            var parameters = new[] {
                new SqlParameter("@table_name", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = tableName },
                new SqlParameter("@key_column", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = keyColumn },
                new SqlParameter("@synchronization_version", SqlDbType.BigInt) { Direction = ParameterDirection.InputOutput, Value = 0 }
            };
            var changes = this.TableChanges.FromSqlRaw("[dbo].[GetTableLastChanges] @table_name, @key_column, @synchronization_version OUTPUT", parameters).ToList();
            synchronizationVersion = Convert.ToInt32(parameters[2].Value);
            return changes;
        }
