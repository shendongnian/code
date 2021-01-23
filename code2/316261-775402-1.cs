    struct Data {
      public string ColumnName; 
    }
    
    var query = (from name in some.Table
                select new Data { ColumnName = name });
    MethodOp(query);
    ...
    MethodOp(IEnumerable<Data> enumerable);
