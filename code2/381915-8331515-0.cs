    using System.Threading;
    public class YourForm
    {
        SynchronizationContext sync;
        public YourForm()
        {
            sync = SynchronizationContext.Current;
            // Any time you need to update controls, call it like this:
            sync.Send(UpdateControls);
        }
    
        public void UpdateControls()
        {
            // Access your controls.
        }
    }
