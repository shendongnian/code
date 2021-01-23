    // ------------------------------------------------------------------------
    public class IdTimeRange : TimeRange
    {
    
      // ----------------------------------------------------------------------
      public IdTimeRange( int id, DateTime start, DateTime end ) :
        base( start, end )
      {
        Id = id;
      } // IdTimeRange    
    
      // ----------------------------------------------------------------------
      public int Id { get; private set; }
    
      // ----------------------------------------------------------------------
      public override string ToString()
      {
        return Id + ": " + base.ToString();
      } // ToString
    
    } // IdTimeRange
