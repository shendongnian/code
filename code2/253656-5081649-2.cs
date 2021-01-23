    class Foo
    {
        public event EventHandler FooEvent;
    
        void LeakMemory()
        {
            Bar bar = new Bar();
    
            bar.AttachEvent(this);
        }
    }
    
    class Bar
    {
        void AttachEvent(Foo foo)
        {
            foo.FooEvent += (sender, e) => { };
        }
    }
