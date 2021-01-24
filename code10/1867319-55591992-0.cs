    public static Task OnExceptionLogError(this Task task, string message)
    {
        task.ContinueWith(t =>
        {
            var exception = t.Exception;
            var innerExceptions = exception.Flatten().InnerExceptions;
            var lines = innerExceptions.Select(ex => $"{ex.GetType().FullName}: {ex.Message}");
            string literal = innerExceptions.Count == 1 ? "an exception" : $"{innerExceptions.Count} exceptions";
            WriteToTextFile($"{message}, {literal} occured on task #{task.Id}:\r\n  " + String.Join("\r\n  ", lines));
        }, TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
        return task;
    }
