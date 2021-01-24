    public class ProcessWithData : Process
    {
        public EventHandler CurrentEventHandler { get; private set; }
        public void SetHandler(EventHandler eventHandler)
        {
            // set Exited via base object
            if (CurrentEventHandler != null) base.Exited -= CurrentEventHandler;
            CurrentEventHandler = eventHandler;
            base.Exited += CurrentEventHandler;
        }
    }
