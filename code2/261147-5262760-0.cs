    [AttributeUsage(AttributeTargets.Class)]
    public class OperationAttribute : System.Attribute
    { 
        public OperationAttribute(string opKey)
        {
            _opKey = opKey;
        }
        
        private string _opKey;
        public string OpKey {get {return _opKey;}}
    }
    [Operation("Standard deviation")]
    public class StandardDeviation : IOperation
    {
        public void Initialize(object originalData)
        {
            //...
        }
    }
    
    public interface IOperation
    {
        void Initialize(object originalData);
    }
    
    public class OperationFactory
    {
        static OperationFactory()
        {
            _opTypesByKey = 
                (from a in AppDomain.CurrentDomain.GetAssemblies()
                 from t in a.GetTypes()
                 let att = t.GetCustomAttributes(typeof(OperationAttribute), false).FirstOrDefault()
                 where att != null
                 select new { ((OperationAttribute)att).OpKey, t})
                 .ToDictionary(e => e.OpKey, e => e.t);
        }
        private static IDictionary<string, Type> _opTypesByKey;
        public IOperation GetOperation(string opKey, object originalData)
        {
            var op = (IOperation)Activator.CreateInstance(_opTypesByKey[opKey]);
            op.Initialize(originalData);
            return op;
        }
    }
