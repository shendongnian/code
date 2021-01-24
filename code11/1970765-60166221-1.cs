CSharp
public class ScopedSession: IDisposable
{
    private bool disposed = false;
    public ScopedSession()
    {
        BeginSession();
    }
    public ~ScopedSession()
    {
        Dispose(false);
    }
    public Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private Dispose(bool disposing)
    {
        if (disposed) return; 
      
        if (disposing) CloseSession();
        disposed = true;
    }
}
public Invoice CreateInvoices(Order order)
{
    using (var s = new ScopedSession())
    {
        // Do stuff
        return invoice;
    }
}
This will ensure a session is closed even if an exception is thrown.
More info at: https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
EDIT: The scoped session constructor may receive an ISessionManager in input, so you can make it testable. The test case would pass a mock object implementing the interface, and yes you can hold a private reference to ISessionManager in the class and null it after closing the session.
