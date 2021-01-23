    /// <summary>
    /// Trace data event handler delegate.
    /// </summary>
    /// <returns>The data to write to the trace listeners</returns>
    public delegate object TraceDataEventHandler();
    public static class Tracing
    {
        /// Trace a verbose message using an undefined event identifier and message.
        /// </summary>
        /// <param name="message">The delegate to call for the trace message if this event should be traced.</param>
        [Conditional("TRACE")]
        public static void TraceVerbose(TraceMessageEventHandler message)
        {
            ... your logic here
        }
    }
