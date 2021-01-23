    public class AndHelper<T>
    {
        protected readonly T val;
        public T And { get { return val; } }
        public AndHelper(T value)
        {
            Contract.Requires(value != null);
            val = value; 
        }
        [ContractInvariantMethod]
        void Invariants()
        {
            Contract.Invariant(And != null);
        }
    }
