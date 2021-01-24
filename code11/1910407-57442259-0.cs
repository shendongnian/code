    namespace MyCode
    {
        public class ArgumentClass
        {
            // TODO: Set this to a useful value of ArgumentClass.
            internal IDontHaveControlOverThis.ArgumentClass InnerArgumentClass { get; }
            public virtual string AnyCall() => "ArgumentClass::AnyCall";
        }
    
        public class ServiceClass
        {
            private IDontHaveControlOverThis.ServiceClass innerServiceClass
                = new IDontHaveControlOverThis.ServiceClass();
    
            public virtual string ServiceCall(ArgumentClass argument)
            {
                return innerServiceClass.ServiceCall(argument.InnerArgumentClass);
            }
        }
    }
