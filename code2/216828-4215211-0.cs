    public static class SyncExtensions {
        public static void InvokeIfRequired(this ISynchronizeInvoke ctrl,
                MethodInvoker method) {
            if(ctrl.InvokeRequired) ctrl.Invoke(method, null);
            else method();
        }
    }
