    public class CalculationFactory
    {
        private static IDependencyResolver _resolver;
        public CalculationFactory(IDependencyResolver resolver)
        {
            ThrowIfNullArgument(resolver, "resolver", typeof(IDependencyResolver));
            _resolver = resolver;
        }
        public static ICalculation CreateCalculator(int serviceType)
        {
            switch (serviceType)
            {
                case 1: return _resolver.Resolve<ICalculation>("Type1");
                case 2: return _resolver.Resolve<ICalculation>("Type2");
                default: return _resolver.Resolve<ICalculation>("InvalidType");
            }
        }
    }
