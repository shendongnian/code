    public class MyExampleModel 
    { 
      public string[] LongPropertyName { get; set; } 
      public string[] L { get { return LongPropertyName; } 
                          set { LongPropertyName = value; } 
                        }
    } 
