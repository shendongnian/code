    public IFooConnector {
        void GetAllCustomers();
    }
    
    public MyFoo14Connector : Foo14Connector, IFooConnector
    {
        // No need to put any code in here!
    }
