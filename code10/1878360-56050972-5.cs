    public class Repository<T> : IRepository<T> where T : new()
        {
            private DbManager context = null;
    
            public Dictionary<string, string> ColumnMap { get; set; }
            ...
            ...
         }
