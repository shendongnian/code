    public static string ToFormattedString(this Exception exception)
    {
        IEnumerable<string> messages = exception
            .GetAllExceptions()
            .Where(e => !String.IsNullOrWhiteSpace(e.Message))
            .Select(e => e.Message.Trim());
        string flattened = String.Join(Environment.NewLine, messages); // <-- the separator here
        return flattened;
    }
    public static IEnumerable<Exception> GetAllExceptions(this Exception exception)
    {
        yield return exception;
        if (exception is AggregateException aggrEx)
        {
            foreach (Exception innerEx in aggrEx.InnerExceptions.SelectMany(e => e.GetAllExceptions()))
            {
                yield return innerEx;
            }
        }
        else if (exception.InnerException != null)
        {
            foreach (Exception innerEx in exception.InnerException.GetAllExceptions())
            {
                yield return innerEx;
            }
        }
    }
