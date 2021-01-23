    interface IPerson
    {
        void Call();
    }
    interface ICustomer : IPerson
    {
    }
    interface IEmployee : IPerson
    {
    }
    class Both
    {
        public ICustomer Customer { get; }
        public IEmployee Employee { get; }
    }
