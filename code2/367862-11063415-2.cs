    public static class DispatcherExtenstions {
        public static void SetAccess(this DispatcherObject d) {
            if(d.CheckAccess()) return;
            Dispatcher dispatcher = d.Dispatcher;
            FieldInfo dispatcherThreadField = typeof(Dispatcher).GetField("_dispatcherThread", BindingFlags.Instance | BindingFlags.NonPublic);
            dispatcherThreadField.SetValue(dispatcher, Thread.CurrentThread);
    }
    }
