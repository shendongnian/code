     public class EventLogWatcher : EventLog
    {
        Action<string, EntryWrittenEventArgs> _changeHandler;
        public EventLogWatcher(string logName, Action<string, EntryWrittenEventArgs> changeHandler)
            : base(logName)
        {
            _changeHandler = changeHandler;
        }
        public void EnableCapture()
        {
            base.EnableRaisingEvents = true;
            base.EntryWritten += EventLogChangeHandler;
        }
        public void DisableCapture()
        {
            base.EnableRaisingEvents = false;
            base.EntryWritten -= EventLogChangeHandler;
        }
        private void EventLogChangeHandler(object sender, EntryWrittenEventArgs e)
        {
            _changeHandler(base.Log, e);
        }
    }
