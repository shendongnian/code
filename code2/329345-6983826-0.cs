        public static void HandleDisposableViewModel(this FrameworkElement Element)
        {
            Action Dispose = () =>
                {
                    var DataContext = Element.DataContext as IDisposable;
                    if (DataContext != null)
                    {
                        DataContext.Dispose();
                    }
                };
            Element.Unloaded += (s, ea) => Dispose();
            Element.Dispatcher.ShutdownStarted += (s, ea) => Dispose();
        }
