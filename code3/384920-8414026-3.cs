     public class SomeClass<T>{
        [ContractInvariantMethod]
        private void THaveUserID()
        {
            Contract.Invariant(typeof(T).GetProperty("UserId") != null);
        }
    }
