    ﻿//DHTMLEventHandler.cs 
    
    using System.Runtime.InteropServices;
    using mshtml;
    
    namespace BHO
    {
        /// 
        /// Generic Event handler for HTML DOM objects.
        /// Handles a basic event object which receives an IHTMLEventObj which
        /// applies to all document events raised.
        /// 
    [ComVisible(true)]
    public class DHTMLEventHandler
    {
        public DHTMLEvent Handler;
        IHTMLDocument2 Document;
        public DHTMLEventHandler(IHTMLDocument2 doc)
        {
            this.Document = doc;
        }
        [DispId(0)]
        public void Call()
        {
            Handler(Document.parentWindow.@event);
        }
    }
    /// 
    /// Generic HTML DOM Event method handler.
    /// 
    public delegate void DHTMLEvent(IHTMLEventObj e);
