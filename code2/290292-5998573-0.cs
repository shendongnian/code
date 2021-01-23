    public class CustomerIdParameter : 
    {
        public CustomerIdParameter(string id) : base("CustomerId", (object)null, false)
        {
            this.Id = id;
        }
    
        public string Id { get; private set; }
    }
 
    kernel.Bind<ISomething>().To<Default>();
    kernel.Bind<ISomething>().To<Other>().When(r => r.Parameters.OfType<CustomerIdParameter>().Single().Id == "SomeName");
    kernel.Get<IWeapon>(new CustomerIdParameter("SomeName")).ShouldBeInstanceOf<Sword>();
   
