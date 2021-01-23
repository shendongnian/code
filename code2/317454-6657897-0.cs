        private string GetSqlCommand(Dictionary<string, Type> schema, string tableName, bool includeIdentity)
        {
            string sql = "CREATE TABLE [" + tableName + "] (\n";
            if (includeIdentity)
                sql += "[ID] int not null Identity(1,1) primary key,\n";
            foreach (KeyValuePair<string, Type> info in schema)
            {
                sql += "[" + info.Key + "] " + SQLGetType(info.Value) + ",\n";
            }
            sql = sql.TrimEnd(new char[] { ',', '\n' }) + "\n";
            return sql + ")";
        }
