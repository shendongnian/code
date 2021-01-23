    partial class Order  { 
      public static readonly string Complete = "Complete"; 
      public static readonly string Pending = "Pending"; 
 
      private static readonly Func<DataContext, Order, bool> _isComplete;
      public static readonly Func<DataContext, Order, bool> IsComplete {
        get {
          if (_isComplete == null) {
            var complete=Complete; 
            _isComplete CompiledQuery.Compile((DataContext context, Order o) => 
                                                           complete == o.Status); 
          }
          return _isComplete;
        }
      }
    }
}
