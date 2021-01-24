public class TryCatchBuilder
{
    private Exception exception;
    private TryCatchBuilder(Exception exception)
    {
        this.exception = exception;
    }
    public static TryCatchBuilder Try(Action action)
    {
        if (action is null)
            throw new ArgumentNullException(nameof(action));
        try
        {
            action();
            return new TryCatchBuilder(null);
        }
        catch (Exception e)
        {
            return new TryCatchBuilder(e);
        }
    }
    public TryCatchBuilder Catch<T>(Action<T> handler) where T : Exception
    {
        if (handler is null)
            throw new ArgumentNullException(nameof(handler));
        if (this.exception is T ex)
        {
            this.exception = null;
            handler(ex);
        }
        return this;
    }
    public void Finally(Action action)
    {
        if (action is null)
            throw new ArgumentNullException(nameof(action));
        action();
    }
}
And used as:
TryCatchBuilder
    .Try(() => throw new ArgumentNullException(""))
    .Catch((ArgumentNullException e) => { })
    .Catch((Exception e) => { })
    .Finally(() => { });
**note** the above does not handle the case where an exception occurs for which there is no handler!
... not that I support this pattern at all: use a normal `try/catch` statement.
