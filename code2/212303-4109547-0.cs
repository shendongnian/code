    public static Chart PopulateInto<T>(
      List<T> yAxis, 
      List<decimal> xAxis) {
      
      return PopulateIntoCore(yAxis, xAxis);
    }
    
    public static Chart PopulateInto<T>(
      List<T> yAxis, 
      List<int> xAxis) {
      
      return PopulateIntoCore(yAxis, xAxis);
    }
    
    private static Chart PopulateIntoCore<T, N>(
      List<T> yAxis, 
      List<N> xAxis) where N : struct {
      ...
    }
