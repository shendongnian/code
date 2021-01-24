    public class ProcessWithData : Process
    {
        public ProcessWithData(string filename)
        {
            base.StartInfo.FileName = filename;
        }
        public EventHandler CurrentEventHandler { get; private set; }
        public void SetHandler(EventHandler eventHandler)
        {
            // set Exited via base object
            if (CurrentEventHandler != null) base.Exited -= CurrentEventHandler;
            CurrentEventHandler = eventHandler;
            base.Exited += CurrentEventHandler;
        }
    }
