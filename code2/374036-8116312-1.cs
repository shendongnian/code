    public static class DispatcherHelper
    {
        public static void DelayInvoke(this Dispatcher dispatcher, TimeSpan ts, Action action)
        {
            DispatcherTimer delayTimer = new DispatcherTimer(DispatcherPriority.Send, dispatcher);
            delayTimer.Interval = ts;
            delayTimer.Tick += (s, e) =>
            {
                delayTimer.Stop();
                action();
            };
            delayTimer.Start();
        }
    }
