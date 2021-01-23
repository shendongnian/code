    public class AndHelper<T>
    {
        private readonly T val;
        
        public AndHelper(T value)
        {
            Contract.Requires(!ReferenceEquals(value, null));
            
            this.val = value;
        }
        
        public virtual T And 
        { 
            get 
            { 
                Contract.Ensures(!ReferenceEquals(Contract.Result<T>(), null));
                
                return this.val; 
            } 
        }
        
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(!ReferenceEquals(val, null));
        }
    
    }
