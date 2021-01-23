    interface IPerson<T>
    {
        void Call();
    }
    interface ICustomer : IPerson<ICustomer>
    {
    }
    interface IEmployee : IPerson<IEmployee>
    {
    }
    class Both : ICustomer, IEmployee
    {
        void IPerson<ICustomer>.Call()
        {
            // Call to external phone number 
        }
        void IPerson<IEmployee>.Call()
        {
            // Call to internal phone number 
        }
    } 
