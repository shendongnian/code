    class Source
    {
        public event EventHandler SomeEvent;
    }
    
    class Listener
    {
        public Listener(Source source)
        {
            // attach an event listner; this adds a reference to the
            // source_SomeEvent method in this instance to the invocation list
            // of SomeEvent in source
            source.SomeEvent += new EventHandler(source_SomeEvent);
        }
    
        void source_SomeEvent(object sender, EventArgs e)
        {
            // whatever
        }
    }
