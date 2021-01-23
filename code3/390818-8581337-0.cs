    class APlugin
    {
        public AAction Action { get; private set; }
    
        APlugin(AAction action)
        {
            Action = action;
        }
    
    }
    
    class BluePlugin: APlugin
    {
        private ActualAction
        {
            get { return Action as BlueAction; }
        }
        BluePlugin(): base(new BlueAction());
        {
        }
    
        void Foo()
        {
            // do stuff with BlueAction's methods
            ActualAction.Foo1();
            ActualAction.Foo2();
        }
    }
