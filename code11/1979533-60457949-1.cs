    public static async void PropagateCompletionAlwaysSuccessful(this IDataflowBlock source,
        IDataflowBlock target)
    {
        try
        {
            await source.Completion.ConfigureAwait(false);
        }
        catch
        {
            // Ignore exception
        }
        finally
        {
            target.Complete();
        }
    }
