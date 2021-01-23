    public IEnumerable<IDataRecord> GetSomeDataById(int MyId)
    {
        return Retrieve(
            "SELECT * FROM [MyTable] WHERE ID= @MyID", 
           cmd =>
           {
              cmd.Parameters.Add("@MyID", SqlDbType.Int).Value = MyId;
           }
         );
    }
