    public IEnumerable<MyClass> GetSomeData()
    {
        using (var cn = Sql.GetOpenConnection())
        {
            //get your data here
        }
    }
