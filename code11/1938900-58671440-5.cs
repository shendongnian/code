    /// <summary>
    /// Gets the result of evaluating filter against given log event.
    /// </summary>
    /// <param name="logEvent">The log event.</param>
    /// <returns>Filter result.</returns>
    internal FilterResult GetFilterResult(LogEventInfo logEvent)
    {
        return Check(logEvent);
    }
