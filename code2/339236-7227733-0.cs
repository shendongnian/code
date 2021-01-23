    public delegate void DHTMLEvent(IHTMLEventObj obj);
   
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class DHTMLEventHandler
    {
        private Thread currentThread;
        public DHTMLEvent Handler;
        private IHTMLDocument2 Document;
        public DHTMLEventHandler(IHTMLDocument2 doc)
        {
            Document = doc;
        }
        [DispId(0)]
         [STAThread]
        public void Call()
        {
            currentThread = Thread.CurrentThread;
           Thread parentWin = new Thread(new ThreadStart(pWindowHandler));
            parentWin.SetApartmentState(ApartmentState.STA);
            parentWin.Start();
            currentThread.Suspend();
           // Handler(Document.parentWindow.@event);
            
        }
        public void pWindowHandler()
        {
            Handler(Document.parentWindow.@event);
            currentThread.Resume();
        }
    }
