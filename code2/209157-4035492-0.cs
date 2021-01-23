    try
    {
       // blah blah blah
    {
    catch(Arithmetic ae)
    {
       HandleArthmeticException( ae );
       HandleGenericException( ae );
    }
    catch(Exception e)
    {
      HandleGenericException( e );
    }
