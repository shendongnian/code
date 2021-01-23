    public class SampleData
    { 
      private static ObservableCollection<Product> _Instance;
    
      public static ObservableCollection<Product> Instance
      {
        get
        {
           // Create a new collection if required.
           if (SampleData._Instance == null)
           {
              // Cache instance in static field.
              SampleData._Instance =  new ObservableCollection<Product>();
           }
           
           // Return new or existing collection.
           return SampleData._Instance;
        }
      }
    }
