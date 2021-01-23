    try
    {
       // blah blah blah
    {
    catch(Arithmetic ae)
    {
       HandleArithmeticException( ae );
       HandleGenericException( ae );
    }
    catch(Exception e)
    {
      HandleGenericException( e );
    }
