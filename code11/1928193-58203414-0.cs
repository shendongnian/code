    public class IWrapper
    {
        void DoTheThing(int foo);
    }
    public QuantumOperationWrapper : IWrapper
    {
        public void DoTheThing(int foo)
        {
            QuantumOperationWrapper.Run(foo);
        }
    }
    public OtherStaticOperationWrapper : IWrapper
    {
        public void DoTheThing(int foo)
        {
            OtherStaticOperationWrapper.Run(foo);
        }
    }
