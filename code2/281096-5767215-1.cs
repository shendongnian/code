    interface IMyInterface
    {
        void Foo();
        UserControl Control { get; }
    }
    
    
    class MyControl : UserControl, IMyInterface
    {
        public void Foo()
        {
            // TODO: Write code here
        }
        
        UserControl IMyInterface.Control
        {
            get { return this; }
        }
    }
