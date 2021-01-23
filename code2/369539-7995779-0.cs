    class YourRow
    {
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        ...
    }
    
    // DataContext takes a connection string as parameter
    var db = new DataContext("Data Source=myServerAddress;" +
        "Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;");
    var rows = db.ExecuteQuery<YourRow>(@"
        select  fk.name,
                object_name(fk.parent_object_id) 'Parent table',
                ...
        ");
