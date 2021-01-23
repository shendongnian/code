    public static class WindowExtensions
    {
            public static void Dispatch(this Control control, Action action)
            {
                if (control.Dispatcher.CheckAccess())
                    action();
                else
                    control.Dispatcher.BeginInvoke(action);
            }
    }
