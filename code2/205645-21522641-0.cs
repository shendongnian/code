        private static System.Threading.SynchronizationContext _UI_Context;
        //call this function once from the UI thread
        internal static void init_CallOnUIThread()
        {
            _UI_Context = System.Threading.SynchronizationContext.Current;
        }
        public static void CallOnUIThread(Action action)
        {
            _UI_Context.Post(new System.Threading.SendOrPostCallback((o) =>
            {
                action();
            }), null);
        }
