    public IEnumerable<IDataRecord> GetSomeDataById(int MyId)
    {
        //I could easily use a stored procedure name instead of a full sql query
        return Retrieve(
            "SELECT * FROM [MyTable] WHERE ID= @MyID", 
           cmd =>
           {
              cmd.Parameters.Add("@MyID", SqlDbType.Int).Value = MyId;
           }
         );
    }
