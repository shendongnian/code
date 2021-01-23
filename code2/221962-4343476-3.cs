    interface IMachineSomething
    {
        void DoSomething();
    }
    class MachineLine : IMachineSomething
    {
        ...
        public void DoSomething() { /* ... */ }
    }
    class MachineCircle : IMachineSomething
    {
        ...
        public void DoSomething() { /* ... */ }
    }
    ...
    foreach (IMachineSomething sth in m)
    {
        sth.DoSomething();
    }
    
