    abstract class Parent
    {
        public Parent()
        {
            Init();
            DoStuff();
        }
    
        protected abstract void DoStuff();
        protected abstract void Init();
    }
    
    class Child : Parent
    {
        public Child()
        {
        }
    
        protected override void Init()
        {
            // needs to be called before doing stuff
        }
    
        protected override void DoStuff() 
        {
            // stuff
        }
    }
