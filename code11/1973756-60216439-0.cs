csharp
public sealed class SyncTaskWrapper
{
    private Func<Task> _action;
    public SyncTaskWrapper(Action action)
        => _action = CreateFunc(action);
    
    private static Func<Task> CreateFunc(Action action)
        => () =>
        {
            try
            {
                action();
                return Task.CompletedTask;
            }
            catch (Exception exception)
            {
                return Task.FromException(exception);
            }
        };
    public static implicit operator Func<Task>(SyncTaskWrapper @this)
        => @this._action;
}
with usage
csharp
_pipe.Enqueue(new SyncTaskWrapper(() =>
    _output = outputBuilder(_results)));
