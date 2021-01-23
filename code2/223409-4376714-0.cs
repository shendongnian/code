    public class Indicator<T>
    {
         public DateTime Timestamp { get; set; }
         public T Value { get; set; }
    }
    public class Repository
    {
         public IEnumerable<Indicator<T>> RetrieveIndicators<T>( DateTime start, DateTime end )
         {
              // determine table to query based on type T
              // query and convert objects to Indicator<T>
              // return collection
         }
    }
