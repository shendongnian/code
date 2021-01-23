    class CustomerCollection
    {
        public IEnumerable<R> Select<R>(Func<Customer, R> projection) {...}
    }
    ....
    customers.Select( (Customer c)=>c.FristNmae );
