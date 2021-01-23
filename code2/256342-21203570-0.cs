    public static class WpfDispatcherUtils
    {
        private static readonly Type dispatcherType = typeof(Dispatcher);
        private static readonly FieldInfo frameDepthField = dispatcherType.GetField("_frameDepth", BindingFlags.Instance | BindingFlags.NonPublic);
        public static bool IsInsideDispatcher()
        {
            // get dispatcher for current thread
            Dispatcher currentThreadDispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            if (currentThreadDispatcher == null)
            {
                // no dispatcher for current thread, we're definitely outside
                return false;
            }
            // get current dispatcher frame depth
            int currentFrameDepth = (int) frameDepthField.GetValue(currentThreadDispatcher);
            return currentFrameDepth != 0;
        }
    }
