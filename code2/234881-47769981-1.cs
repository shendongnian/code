      public class UtcDbDataReader : DbDataReader
        {
            private readonly DbDataReader source;
    
            public UtcDbDataReader(DbDataReader source)
            {
                this.source = source;
            }
    
          public override DateTime GetDateTime(int ordinal)
            {
                return DateTime.SpecifyKind(source.GetDateTime(ordinal), DateTimeKind.Utc);
            }        
     
            // you need to fill all overrides, just call same method on source in all cases
    
              public new void Dispose()
            {
                source.Dispose();
            }
    
            public new IDataReader GetData(int ordinal)
            {
                return source.GetData(ordinal);
            }
       }
