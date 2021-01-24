    public static Task<bool> OnCancelReturnTrue(this Task task)
    {
        return task.ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                if (t.Exception.InnerException is WebException webEx
                    && webEx.Status == WebExceptionStatus.RequestCanceled) return true;
                throw t.Exception;
            }
            return t.IsCanceled;
        }, TaskContinuationOptions.ExecuteSynchronously);
    }
