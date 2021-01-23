    try
    {
      DoignStuff();
    }
    catch( Exception ex)
    {
    Trace.WriteLine( "Exception in <Page Name>  while calling DoingStuff() Ex:"+ ex.ToString() );
    }
