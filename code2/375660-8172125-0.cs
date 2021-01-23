        protected override void OnException(ExceptionContext filterContext)
        {
            EventLog.WriteEntry("MyAppError", filterContext.Exception.ToString(), EventLogEntryType.Error);
            base.OnException(filterContext);
        }
