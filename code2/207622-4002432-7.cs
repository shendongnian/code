    public IEnumerable<IDataRecord> GetSomeDataById(int MyId)
    {
        return Retrieve(
            "SELECT * FROM [MyTable] WHERE ID= @MyID", 
           p =>
           {
              p.Add("@MyID", SqlDbType.Int).Value = MyId;
           }
         );
    }
