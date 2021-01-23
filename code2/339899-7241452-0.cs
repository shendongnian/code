    // ----------------------------------------------------------------------
    public long GetTicksOfDay( DateTime moment )
    {
      return moment.Subtract( moment.Date ).Ticks;
    } // GetTicksOfDay
