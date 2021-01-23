    SQLServerDBInsert(int id, string name, bool active)
    {
       string query = "INSERT INTO MyTable(ID, Name, Active) VALUES(@id, @name, @active)";
       using(SqlCommand cmd = new SqlCommand(query, conn))
       {
         SqlParamter param = new SqlParameter();
         param.ParameterName = "@id";
         param.Value = id;
         param.SqlDbType = SqlDbType.Int;
         cmd.Parameters.Add(param);
         ....
       }
    }
