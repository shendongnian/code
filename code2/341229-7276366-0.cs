    /// <summary>
    /// Helper class that allows synchronized invoking to be performed in a single line of code.
    /// </summary>
    internal static class SynchronizedInvoke {
        /// <summary>
        /// Invokes the specified action on the thread that the specified sync object was created on.
        /// </summary>
        public static void Invoke(ISynchronizeInvoke sync, Action action) {
            if (!sync.InvokeRequired) {
                action();
            }
            else {
                object[] args = new object[] { };
                sync.Invoke(action, args);
            }
        }
    }
