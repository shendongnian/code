    bool fooSuccess = foo.Method(...);
    if ( fooSuccess )
    {
      bool barSuccess = bar.Method(...);
      if ( barSuccess )
      {
        // The normal course of events -- do the usual thing
      }
      else
      {
        // deal with bar.Method() failure
      }
    }
    else // foo.Method() failed
    {
      // deal with foo.Method() failure
    }
