        static public void ShowSplash()
        {
            _shouldClose = false;
            Thread t = new Thread(ThreadFunc);
            t.Priority = ThreadPriority.Lowest;
            t.Start();
        }
        internal static void RemoveSplash()
        {
            _shouldClose = true;
        }
