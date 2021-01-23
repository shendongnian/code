    public class MySynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            Thread t = new Thread(d.Invoke);
            t.SetApartmentState(ApartmentState.STA);
            t.Start(state);
        }
    }
