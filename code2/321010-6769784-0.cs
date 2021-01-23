    /// Inside the BHO.cs file and in my namespace
    /// Generic HTML DOM Event method handler.
    ///
    public delegate void DHTMLEvent(IHTMLEventObj e);
    ///
    /// Generic Event handler for HTML DOM objects.
    /// Handles a basic event object which receives an IHTMLEventObj which
    /// applies to all document events raised.
    ///
    public class DHTMLEventHandler
    {
        public DHTMLEvent Handler;
        HTMLDocument Document;
        public DHTMLEventHandler(HTMLDocument doc)
        {
            this.Document = doc;
        }
        [DispId(0)]
        public void Call()
        {
            Handler(Document.parentWindow.@event);
        }
    }
        public void BrowserEventHandler(IHTMLEventObj e)
        {
            try
            {
                if (e.type == "click" && e.srcElement.id == "IDOfmyButton")
                {
                    // do something.
                    something();
                }
            }
            catch
            {
            }
        }
