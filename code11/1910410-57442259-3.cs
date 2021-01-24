    public class MyArgumentClass
    {
            // TODO: Set this to a useful value of ArgumentClass.
        internal IDontHaveControlOverThis.ArgumentClass InnerArgumentClass { get; }
        public virtual string AnyCall() => "???";
    }
    
    public class MyServiceClass
    {
        private IDontHaveControlOverThis.ServiceClass innerServiceClass
                = new IDontHaveControlOverThis.ServiceClass();
    
        public virtual string ServiceCall(MyArgumentClass argument)
        {
            return innerServiceClass.ServiceCall(argument.InnerArgumentClass);
        }
    }
