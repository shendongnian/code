    DateTime gapStart = dtFrom.AddDays( 0 );
    for ( int i = 1 ; i < totaldays ; i++ )
    {
      if ( list[i] )
      {
        var whgap  = new WorkHistoryGap();
        whgap.From = gapStart.Value; //unassigned variable error
        whgap.To = dtFrom.AddDays( i );
        return whgap;
      }
    }
