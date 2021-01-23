      enum NamingConvention 
      {
        Unformatted,
        CamelCase,
        ProperCase
      }
      public class Preferences
      {
        public NamingConvention FieldNamingConvention { get; set; }
        // .. Other settings
    
    
        // Function to get the formatter depending on the FieldNamingConvention
        public IIdentifierFormatter GetFieldNameFormatter()
        {
          switch (FieldNamingConvention)
          {
            case NamingConvention.Unformatted:
              return new ProperCaseIdenifierFormatter();
            case NamingConvention.CamelCase:
              return new ProperCaseIdenifierFormatter();
            case NamingConvention.ProperCase:
              return new ProperCaseIdenifierFormatter();          
            default:
              throw new Exception("Invalid or unsupported field naming convention.");
          }      
        }
      }
