    public class MyArgumentClass
    {
        public virtual string AnyCall() => "???";
    }
    
    public class MyServiceClass
    {
        private IDontHaveControlOverThis.ServiceClass innerServiceClass
                = new IDontHaveControlOverThis.ServiceClass();
    
        public string ServiceCall(MyArgumentClass argument)
        {
            var serviceArgument = Convert(argument);
            return innerServiceClass.ServiceCall(serviceArgument);
        }
        private IDontHaveControlOverThis.ArgumentClass Convert(MyArgumentClass argument)
        {
            // TODO: implement.
        }
    }
