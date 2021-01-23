    public static void Invoke(ISynchronizeInvoke sync, Action action) {
        if (!sync.InvokeRequired) {
            action();
        }
        else {
            object[] args = new object[] { };
            sync.Invoke(action, args);
        }
    }
