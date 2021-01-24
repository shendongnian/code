    public static void WorkUntilFinishedOrCancelled(CancellationToken token, params Action[] work)
    {
        foreach (var workItem in work)
        {
            token.ThrowIfCancellationRequested();
            workItem();
        }
    }
