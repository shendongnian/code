    public class StringNTextConvention : Convention {
      public StringNTextConvention() {
        Properties<string>().Configure(p => p.HasColumnType("ntext"));                    
      }
    }
