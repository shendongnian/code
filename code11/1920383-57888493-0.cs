        public ExecuteCommand(string columnName,List<string> values)
        {
            //here 'command' is instance variable of IDbCommand class, to execute command text in database
            string sql = "alter table TableName add ColumnName DatatypeOfColumn ";
            command.CommandText = sql;
            command.ExecuteScalar();
            foreach(string value in values)
            {
                sql = "update table TableName set ColumnName="+ value + " where condition ";
                command.CommandText = sql;
                command.ExecuteScalar();
            }
        }
