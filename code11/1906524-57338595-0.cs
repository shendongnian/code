    public static IDisposable OnClickAndHold(Control control, int delay,
        MouseButtonEventHandler handler)
    {
        bool handleMouseDown = true;
        bool handleOtherEvents = false;
        RoutedEventArgs eventArgsToRepeat = null;
        CancellationTokenSource cts = null;
        control.MouseDown += Control_MouseDown;
        control.MouseUp += Control_MouseUp;
        return new Disposer(() =>
        {
            control.MouseDown -= Control_MouseDown;
            control.MouseUp -= Control_MouseUp;
        });
        async void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!handleMouseDown || e.ClickCount > 1) return;
            e.Handled = true;
            var clonedArgs = CloneArgs(e);
            try
            {
                cts = new CancellationTokenSource();
                handleOtherEvents = true;
                await Task.Delay(delay, cts.Token);
                handleOtherEvents = false;
            }
            catch (TaskCanceledException)
            {
                handleOtherEvents = false;
                try
                {
                    handleMouseDown = false;
                    control.RaiseEvent(clonedArgs);
                }
                finally
                {
                    handleMouseDown = true;
                }
                control.RaiseEvent(eventArgsToRepeat);
                return;
            }
            handler(sender, clonedArgs);
        }
        void Control_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!handleOtherEvents) return;
            e.Handled = true;
            eventArgsToRepeat = CloneArgs(e);
            cts?.Cancel();
        }
        MouseButtonEventArgs CloneArgs(MouseButtonEventArgs e)
        {
            return new MouseButtonEventArgs(e.MouseDevice, e.Timestamp,
                e.ChangedButton)
            {
                RoutedEvent = e.RoutedEvent,
                Source = control,
            };
        }
    }
    public struct Disposer : IDisposable
    {
        private readonly Action _action;
        public Disposer(Action action) => _action = action;
        public void Dispose() => _action();
    }
