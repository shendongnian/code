    public class SummaryData
    {
      public SummaryData( int id )
      {
        this.SummaryId   = id ;
        this.TotalNumber = 0  ;
      }
      public int SummaryId   { get; set; }
      public int TotalNumber { get; set; }
    }
    
    public class ListItem
    {
      public int      Id     ;
      public int      Number ;
      public DateTime Time   ;
    }
    
    public IEnumerable<SummaryData> Summarize( IEnumerable<ListItem> ItemList )
    {
      const long                        TICKS_PER_QUARTER_HOUR = TimeSpan.TicksPerMinute * 15;
      SortedDictionary<int,SummaryData> summary                = new SortedDictionary<int , SummaryData>();
      
      foreach ( ListItem item in ItemList )
      {
        long TimeOfDayTicks     = item.Time.TimeOfDay.Ticks;
        bool on15MinuteBoundary = ( 0 == TimeOfDayTicks % TICKS_PER_QUARTER_HOUR ? true : false );
        
        if ( on15MinuteBoundary )
        {
          int         key      = (int)( TimeOfDayTicks / TICKS_PER_QUARTER_HOUR );
          SummaryData value;
          bool        hasValue = summary.TryGetValue( key , out value );
          
          if ( !hasValue )
          {
            value = new SummaryData( item.Id );
            summary.Add( value.SummaryId , value ) ;
          }
          value.TotalNumber += item.Number;
          
        }
        
      }
      
      return summary.Values;
      
    }
