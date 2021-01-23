    class ThreadedMethods {
        public static void Parameterized<T>(Action<T> action) {
            // Start the action on a different thread using possibly ThreadPool.QueueUserWorkItem
        }
    }
