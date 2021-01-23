    interface ISystem
    {
        void DoSomething();
    }
    
    class SystemA : ISystem
    {
       public void DoSomething() { /* handle the system A case*/ }
    }
    
    class SystemB : ISystem
    {
       public void DoSomething() { /* handle the system B case */ }
    }
