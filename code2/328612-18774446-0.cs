    public abstract class CustomTraceListener : TraceListener
    {
        private static readonly TraceSource Trace = new TraceSource("PostmarkTraceListener");
        /// <summary>
        /// Construct an instance of the trace listener
        /// </summary>
        /// <param name="name">The name of the trace listener</param>
        protected CustomTraceListener(string name)
            : base(name)
        {
            
        }
        #region Abstracts
        /// <summary>
        /// This method must be overriden and forms the core logging method called by all other TraceEvent methods.
        /// </summary>
        /// <param name="eventCache">A cache of data that defines the trace event</param>
        /// <param name="source">The trace source</param>
        /// <param name="eventType">The type of event</param>
        /// <param name="id">The unique ID of the trace event</param>
        /// <param name="message">A message to be output regarding the trace event</param>
        protected abstract void TraceEventCore(TraceEventCache eventCache, string source, TraceEventType eventType,
                                               int id, string message);
        /// <summary>
        /// This method must be overriden and forms the core logging method called by all otherTraceData methods.
        /// </summary>
        /// <param name="eventCache">A cache of data that defines the trace event</param>
        /// <param name="source">The trace source</param>
        /// <param name="eventType">The type of event</param>
        /// <param name="id">The unique ID of the trace event</param>
        /// <param name="data">The data to be logged</param>
        protected abstract void TraceDataCore(TraceEventCache eventCache, string source, TraceEventType eventType,
                                              int id, params object[] data);
        #endregion
        #region TraceData/TraceEvent Overrides
        /// <summary>
        /// Write a trace event
        /// </summary>
        /// <param name="eventCache">A cache of data that defines the trace event</param>
        /// <param name="source">The trace source</param>
        /// <param name="eventType">The type of event</param>
        /// <param name="id">The unique ID of the trace event</param>
        /// <param name="message">A message to be output regarding the trace event</param>
        public override sealed void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType,
                                               int id, string message)
        {
            FilterTraceEventCore(eventCache, source, eventType, id, message);
        }
        /// <summary>
        /// Write a trace event
        /// </summary>
        /// <param name="eventCache">A cache of data that defines the trace event</param>
        /// <param name="source">The trace source</param>
        /// <param name="eventType">The type of event</param>
        /// <param name="id">The unique ID of the trace event</param>
        /// <param name="format">A string format specification for the trace event</param>
        /// <param name="args">Arguments used within the format specification string</param>
        public override sealed void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType,
                                               int id, string format, params object[] args)
        {
            string message = string.Format(CultureInfo.CurrentCulture, format, args);
            FilterTraceEventCore(eventCache, source, eventType, id, message);
        }
        /// <summary>
        /// Write a trace event
        /// </summary>
        /// <param name="eventCache">A cache of data that defines the trace event</param>
        /// <param name="source">The trace source</param>
        /// <param name="eventType">The type of event</param>
        /// <param name="id">The unique ID of the trace event</param>
        public override sealed void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType,
                                               int id)
        {
            FilterTraceEventCore(eventCache, source, eventType, id, null);
        }
        /// <summary>
        /// Write a trace event
        /// </summary>
        /// <param name="eventCache">A cache of data that defines the trace event</param>
        /// <param name="source">The trace source</param>
        /// <param name="eventType">The type of event</param>
        /// <param name="id">The unique ID of the trace event</param>
        /// <param name="data">The data to be written</param>
        public override sealed void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType,
                                              int id, object data)
        {
            FilterTraceDataCore(eventCache, source, eventType, id, data);
        }
        /// <summary>
        /// Write a trace event
        /// </summary>
        /// <param name="eventCache">A cache of data that defines the trace event</param>
        /// <param name="source">The trace source</param>
        /// <param name="eventType">The type of event</param>
        /// <param name="id">The unique ID of the trace event</param>
        /// <param name="data">The data to be written</param>
        public override sealed void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType,
                                              int id, params object[] data)
        {
            FilterTraceDataCore(eventCache, source, eventType, id, data);
        }
        #endregion
        #region Write Methods
        /// <summary>
        /// Write a message to the trace listeners
        /// </summary>
        /// <param name="message">The message to write</param>
        public override void Write(string message)
        {
            FilterTraceEventCore(null, string.Empty, TraceEventType.Information, 0, message);
        }
        /// <summary>
        /// Write a message to the trace listeners
        /// </summary>
        /// <param name="message">The message to write</param>
        public override void WriteLine(string message)
        {
            Write(message);
        }
        #endregion
        #region ShouldTrace
        
        /// <summary>
        /// Determines whether a filter is attached to this listener and, if so, asks whether it ShouldTrace applies to this data.
        /// </summary>
        protected virtual bool ShouldTrace(TraceEventCache eventCache, string source, TraceEventType eventType, int id,
                                           string formatOrMessage, object[] args, object data1, object[] data)
        {
            return !(Filter != null && !Filter.ShouldTrace(eventCache, source, eventType, id, formatOrMessage, args, data1, data));
        }
        #endregion
        #region FilterTraceCore
        /// <summary>
        /// Called before the main TraceEventCore method and applies any filter by calling ShouldTrace.
        /// </summary>
        protected virtual void FilterTraceEventCore(TraceEventCache eventCache, string source, TraceEventType eventType,
                                                    int id, string message)
        {
            try
            {
                if (!ShouldTrace(eventCache, source, eventType, id, message, null, null, null))
                    return;
                TraceEventCore(eventCache, source, eventType, id, message);
            }
            catch (Exception exc)
            {
                Trace.TraceEvent(TraceEventType.Error, 0, "{0}", exc);
            }
        }
        /// <summary>
        /// Called before the main TraceDataCore method and applies any filter by calling ShouldTrace.
        /// </summary>
        protected virtual void FilterTraceDataCore(TraceEventCache eventCache, string source, TraceEventType eventType,
                                                   int id, params object[] data)
        {
            try
            {
                if (!ShouldTrace(eventCache, source, eventType, id, null, null, null, data))
                    return;
                TraceDataCore(eventCache, source, eventType, id, data);
            }
            catch (Exception exc)
            {
                Trace.TraceEvent(TraceEventType.Error, 0, "{0}", exc);
            }
        }
        #endregion
    }
