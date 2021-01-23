        public interface IInstrumentRepo : IRepo<Instrument>
        { 
            // nothing to do here
        }
        public interface ICustomerRepo : IRepo<Customer>
        {
            // but we'll need a custom method here
            void FindByAddress(string address);
        }
        public interface IRepo<T> 
        {
            T GetById(object id);
            T Save(T item);
        }
