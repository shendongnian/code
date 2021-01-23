    class MyTable
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
    }
    var db = DatabaseFactory.CreateDatabase("Default");
    var genericList = db.ExecuteSqlStringAccessor<MyTable>("select * from mytable").ToList();
