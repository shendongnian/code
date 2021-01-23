        try
        {
        }
        catch ( Exception ex )
        {
            My.API.ErrorHandler.Handler.HandleError( ex, System.Reflection.MethodBase.GetCurrentMethod().Name, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName );
        }
