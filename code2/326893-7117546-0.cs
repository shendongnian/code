    class TupleIntDynamicParam : Dapper.SqlMapper.IDynamicParameters
    {
        IEnumerable<int> tuples;
        public IntDynamicParam(IEnumerable<Tuple<int,int>> tuples)
        {
            this.tuples= tuples;
        }
    
        public void AddParameters(IDbCommand command)
        {
            var sqlCommand = (SqlCommand)command;
            sqlCommand.CommandType = CommandType.StoredProcedure;
    
            List<Microsoft.SqlServer.Server.SqlDataRecord> number_list = 
               new List<Microsoft.SqlServer.Server.SqlDataRecord>();
    
            // Create an SqlMetaData object that describes our table type.
            Microsoft.SqlServer.Server.SqlMetaData[] tvp_definition = { 
              new Microsoft.SqlServer.Server.SqlMetaData("n", SqlDbType.Int), 
              new Microsoft.SqlServer.Server.SqlMetaData("n2", SqlDbType.Int) };
    
            foreach (int n in tuples)
            {
                // Create a new record, using the metadata array above.
                Microsoft.SqlServer.Server.SqlDataRecord rec = 
                    new Microsoft.SqlServer.Server.SqlDataRecord(tvp_definition);
                rec.SetInt32(0, n.Item1);
                rec.SetInt32(1, n.Item2);
                number_list.Add(rec);      // Add it to the list.
            }
    
            // Add the table parameter.
            var p = sqlCommand.Parameters.Add("ints", SqlDbType.Structured);
            p.Direction = ParameterDirection.Input;
            p.TypeName = "int_tuple_list_type";
            p.Value = number_list;
    
        }
    }
