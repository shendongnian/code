    [ContractClass(typeof(IInitialiseContract))]
    public interface IInitialise
    {
        bool IsInitialised { get; }
        void Initialise();
    }
    [ContractClassFor(typeof(IInitialise))]
    public abstract class IInitialiseContract : IInitialise
    {
        public bool IsInitialised
        {
            get { return default(bool); }
        }
        public void Initialise()
        {
            Contract.Ensures(IsInitialised == true);
        }
    }
