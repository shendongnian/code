    class SomeClient
    {
        private readonly SomeEventSource _source;
        public SomeClient()
        {
            _source = new SomeEventSource();
            _source.MyEvent += source_MyEvent;
        }
        public void RunTest()
        {
            _source.FireTheEvent();
        }
        void source_MyEvent(object sender, EventArgs e)
        {
            // Do something
        }
    }
