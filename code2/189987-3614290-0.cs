    public boolean MeetingIsValid( DateTime start, DateTime end )
    {
          if( start < DateTime.Now || end < DateTime.Now )
              return false;
          return start > end || end < start;
    }
