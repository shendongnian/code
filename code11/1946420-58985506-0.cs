    public static Func<TInput, Task> Enhance<TInput>(
        Func<TInput, Task> action,
        Action<TInput> onActionStarted = null,
        Action<TInput> onActionFinished = null,
        ISynchronizeInvoke synchronizingObject = null)
    {
        return async (item) =>
        {
            RaiseEvent(onActionStarted, item, synchronizingObject);
            await action(item).ConfigureAwait(false);
            RaiseEvent(onActionFinished, item, synchronizingObject);
        };
    }
    private static void RaiseEvent<T>(Action<T> onEvent, T arg1,
        ISynchronizeInvoke synchronizingObject)
    {
        if (onEvent == null) return;
        if (synchronizingObject != null && synchronizingObject.InvokeRequired)
        {
            synchronizingObject.Invoke(onEvent, new object[] { arg1 });
        }
        else
        {
            onEvent(arg1);
        }
    }
