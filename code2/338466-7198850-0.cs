    public void List( Dictionary<string,DateTime> dict )
    {
      int i = 0 ;
      foreach( KeyValuePair<string,DateTime> entry in dict.OrderBy( x => x.Value ).ThenByDescending( x => x.Key ) )
      {
        Console.WriteLine( "{0}. Key={1}, Value={2}" , ++i , entry.Key , entry.Value ) ;
      }
      Console.WriteLine( "The dictionary contained a total of {0} entries." , i ) ;
    }
