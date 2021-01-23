    public class TestDynamicFactory
    {
        // static storage
        private static Dictionary<string, Func<ICalculate>> InstanceCreateCache = new Dictionary<string, Func<ICalculate>>();
        // how to invoke it
        static int Main()
        {
            // invoke it, this is lightning fast and the first-time cache will be arranged
            // also, no need to give the full method anymore, just the classname, as we
            // use an interface for the rest. Almost full type safety!
            ICalculate instanceOfCalculator = this.CreateCachableICalculate("RandomNumber");
            int result = instanceOfCalculator.ExecuteCalculation();
        }
        // searches for the class, initiates it (calls factory method) and returns the instance
        // TODO: add a lot of error handling!
        ICalculate CreateCachableICalculate(string className)
        {
            if(!InstanceCreateCache.ContainsKey(className))
            {
                // get the type (several ways exist, this is an eays one)
                Type type = TypeDelegator.GetType("AirportListTest." + className);
                // NOTE: do NOT use the following, because you cannot create a delegate from a ctor!
                ConstructorInfo constructorInfo = type.GetConstructor(Type.EmptyTypes);
                // works with public instance/static methods
                MethodInfo mi = type.GetMethod("Create");
                // the "magic", turn it into a delegate
                var createInstanceDelegate = (Func<ICalculate>) Delegate.CreateDelegate(typeof (Func<ICalculate>), mi);
                // store for future reference
                InstanceCreateCache.Add(className, createInstanceDelegate);
            }
            return InstanceCreateCache[className].Invoke();
        }
    }
    // example of your ICalculate interface
    public interface ICalculate
    {
        void Initialize();
        int ExecuteCalculation();
    }
    // example of an ICalculate class
    public class RandomNumber : ICalculate
    {
        private static Random  _random;
        public static RandomNumber Create()
        {
            var random = new RandomNumber();
            random.Initialize();
            return random;
        }
        public void Initialize()
        {
            _random = new Random(DateTime.Now.Millisecond);
        }
        public int ExecuteCalculation()
        {
            return _random.Next();
        }
    }
