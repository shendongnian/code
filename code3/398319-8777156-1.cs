    public static void Main()
    {
        var ui = SynchronizationContext.Current;
        new Thread ( () => Go( ui ) ).Start();
    }
	static void HandleException( Exception ex )
	{
		// this will be run on the UI thread
	}
    static void Go( SynchronizationContext ui )
    {
        try
        {
            // ...
            throw null;    // The NullReferenceException will get caught below
            // ...
        }
        catch (Exception ex) 
        {
            ui.Send( state => HandleException( ex ), null );
        }
    }
