    private void button1_Click(object sender, EventArgs e)
    {
        AppDomain domain1 = AppDomain.CreateDomain("domain1");
        AppDomain domain2 = AppDomain.CreateDomain("domain2");
        DomainObject object1 = 
            domain1.CreateInstanceAndUnwrap("MyLibrary", "MyLibrary.DomainObject") 
            as DomainObject;
        
        DomainObject object2 = 
            domain2.CreateInstanceAndUnwrap("MyLibrary", "MyLibrary.DomainObject") 
            as DomainObject;
        if (object1 != null)
        {
            Console.WriteLine("object 1 Value = " 
                              + object1.GetIncrementedValue().ToString());
            Console.WriteLine("object 1 Value = " 
                              + object1.GetIncrementedValue().ToString());
            Console.WriteLine("object 1 Value = " 
                              + object1.GetIncrementedValue().ToString());
        }
        if (object2 != null)
        {
            Console.WriteLine("object 2 Value = "
                              + object2.GetIncrementedValue().ToString());
            Console.WriteLine("object 2 Value = "
                              + object2.GetIncrementedValue().ToString());
            Console.WriteLine("object 2 Value = "
                              + object2.GetIncrementedValue().ToString());
        }
        /* Unload the Domain and re-create
         * This should reset the Static Value in the AppDomain
         */
        AppDomain.Unload(domain1);
        domain1 = AppDomain.CreateDomain("domain1");
        object1 = domain1.CreateInstanceAndUnwrap("MyLibrary", 
                                                  "MyLibrary.DomainObject") 
                                                  as DomainObject;
        if (object1 != null)
        {
            Console.WriteLine("object 1 Value = "
                              + object1.GetIncrementedValue().ToString());
            Console.WriteLine("object 1 Value = "
                              + object1.GetIncrementedValue().ToString());
            Console.WriteLine("object 1 Value = "
                              + object1.GetIncrementedValue().ToString());
        }
        if (object2 != null)
        {
            Console.WriteLine("object 2 Value = "
                              + object2.GetIncrementedValue().ToString());
            Console.WriteLine("object 2 Value = "
                              + object2.GetIncrementedValue().ToString());
            Console.WriteLine("object 2 Value = "
                              + object2.GetIncrementedValue().ToString());
        }
    }
