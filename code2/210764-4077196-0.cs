    public static class FocusEnforcer
    {
        public static void EnforceFocus(UIElement element)
        {
            if (!element.Focus())
            {
                element.Dispatcher.BeginInvoke(DispatcherPriority.Input, 
                                                new ThreadStart(delegate()
                                                                {
                                                                    element.Focus();
                                                                }));
            }
        }
    }
