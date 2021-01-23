    interface IWhatever 
    {
      // central Id for the whole table
      int Id { get; set; }
      // may be some more properties
    }
    class Product : IWhatever
    {
      // ...
    }
    
    class HourlyRate : IWhatever
    {
      // ...
    }
    
    class TextLines : IWhatever
    {
      // ...
    }
    
