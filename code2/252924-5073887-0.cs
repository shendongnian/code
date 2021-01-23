    [ContractClass(typeof(IAContracts))]
    interface IA
    {
        void Foo(int x);
    }
    
    [ContractClass(typeof(IBContracts))]
    interface IB : IA
    {
        void Bar(int y);
    }
    [ContractClassFor(typeof(IA))]
    abstract class IAContracts : IA
    {
        public void Foo(int x)
        {
            Contract.Requires(x >= 0);
        }
    }
    [ContractClassFor(typeof(IB))]
    abstract class IBContracts : IB
    {
        // inherited from IA
        public abstract void Foo(int x);
        // declared in IB
        public void Bar(int y)
        {
            Contract.Requires(y >= 0);
        }
    }
