    public class AsyncHelper
    {
        public static void EnsureUIThread(Action action) 
        {
            if (Application.Current != null && !Application.Current.Dispatcher.CheckAccess()) 
            {
                Application.Current.Dispatcher.BeginInvoke(action, DispatcherPriority.Background);
            }
            else 
            {
                action();
            }
        }
    }
