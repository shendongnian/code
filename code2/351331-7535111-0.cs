    // Implementation of a manual event class with a DelayedSet method
    // DelayedSet will set the event after a delay period
    // TODO: Improve exception handling
    public sealed class DelayedManualEvent : EventWaitHandle
    {
        private SysTimer timer; // using SysTimer = System.Timers.Timer;
        public DelayedManualEvent() :
            base(true, EventResetMode.ManualReset)
        {
            timer = new SysTimer();
            timer.AutoReset = false;
            timer.Elapsed +=new ElapsedEventHandler(OnTimeout);
        }
        public bool DelayedSet(TimeSpan delay)
        {
            bool result = false;
            try
            {
                double timeout = delay.TotalMilliseconds;
                if (timeout > 0 && timer != null && Reset())
                {
                    timer.Interval = timeout;
                    timer.Start();
                    result = true;
                    Trace.TraceInformation("DelayedManualEvent.DelayedSet Event will be signaled in {0}ms",
                        delay);
                }
            }
            catch (Exception e)
            {
                Trace.TraceError("DelayedManualEvent.DelayedSet Exception {0}\n{1}", 
                    e.Message, e.StackTrace);
            }
            return result;
        }
        private void OnTimeout(object source, ElapsedEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                Trace.TraceInformation("DelayedManualEvent.OnTimeout Event signaled at time {0}", e.SignalTime);
            }
            try
            {
                if (!Set())
                {
                    Trace.TraceError("DelayedManualEvent.OnTimeout Event set failed");
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("DelayedManualEvent.OnTimeout Exception in signaling event\n{0}]\n{1}",
                    ex.Message, ex.StackTrace);
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (timer != null)
            {
                timer.Dispose();
            }
            base.Dispose(disposing);
        }
    }
