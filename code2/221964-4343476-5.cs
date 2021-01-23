    interface IMachineSomething
    {
        void DoSomething();
    }
    class MachineLine : IMachineSomething
    {
        ...
        public void DoSomething() { DoThis(); }
    }
    class MachineCircle : IMachineSomething
    {
        ...
        public void DoSomething() { DoThat(); }
    }
    ...
    foreach (IMachineSomething sth in m)
    {
        sth.DoSomething();
    }
    
