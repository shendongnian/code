    class Listener
    {
        private Source _source;
        public Listener(Source source)
        {
            _source = source;
            // attach an event listner; this adds a reference to the
            // source_SomeEvent method in this instance to the invocation list
            // of SomeEvent in source
            _source.SomeEvent += source_SomeEvent;
        }
    
        void source_SomeEvent(object sender, EventArgs e)
        {
            // whatever
        }
       
        public void Close()
        {
            if (_source != null)
            {
                // detach event handler
                _source.SomeEvent -= source_SomeEvent;
                _source = null;
            }
        }
    }
