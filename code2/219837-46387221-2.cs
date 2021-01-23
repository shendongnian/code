    [AttributeUsage(AttributeTargets.Class, AllowMultiple =false)]
    public class MyAttribute : ValidationAttribute
    {
        
        AlgorithmTypes AlgorithmType;
    
        public MyAttribute(AlgorithmTypes algorithm = AlgorithmTypes.None)
        {
            AlgorithmType = algorithm;
        }
    
        public override bool IsValid(object value)
        {
    
            return (AlgorithmStrategyFactory.Create(AlgorithmType)).IsValid(Properties, value);
        }
    
    
        /// <summary>
        /// Factory for this 
        /// </summary>
        public class AlgorithmStrategyFactory
        {
            private static ArrayList _registeredImplementations;
    
            static AlgorithmStrategyFactory()
            {
                _registeredImplementations = new ArrayList();
                RegisterClass(typeof(NoneValidationMode));
                RegisterClass(typeof(AllValidationMode));
                RegisterClass(typeof(AtLeastOneValidationMode));
            }
            public static void RegisterClass(Type requestStrategyImpl)
            {
                if (!requestStrategyImpl.IsSubclassOf(typeof(RequiredValidationMode)))
                    throw new Exception("requestStrategyImpl  must inherit from class RequiredValidationMode");
    
                _registeredImplementations.Add(requestStrategyImpl);
            }
            public static RequiredValidationMode Create(AlgorithmTypes algorithmType)
            {
                // loop thru all registered implementations
                foreach (Type impl in _registeredImplementations)
                {
                    // get attributes for this type
                    object[] attrlist = impl.GetCustomAttributes(true);
    
                    // loop thru all attributes for this class
                    foreach (object attr in attrlist)
                    {
                        if (attr is AlgorithmAttribute)
                        {
                            if (((AlgorithmAttribute)attr).AlgorithmType.Equals(algorithmType))
                            {
                                return (RequiredValidationMode)System.Activator.CreateInstance(impl);
                            }
                        }
                    }
                }
                throw new Exception("Could not find a RequiredValidationMode implementation for this AlgorithmType");
            }
        }
