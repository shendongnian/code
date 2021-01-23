    public interface ITradingApiFactory
    {
        ITradingApi Create();
        IEnumerable<Parameter> Parameters { get; }
    }
    public class Parameter
    {
        public Parameter(Type type, string name, string description)
        { Type = type; Name = name; Description = description; }
        public Type Type { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public object Value { get; set; }
    }
    public class MT4TradingApiFactory
    {
        Dictionary<string, Parameter> _parameters;
        
        public MT4TradingApiFactory()
        { /* init _parameters */ }
        public ITradingApi Create()
        {
            return new MT4TradingApi(_parameters["hostname"].ToString(),
                                     (int)_parameters["port"]);
        }
        IEnumerable<Parameter> Parameters { get { return _parameters.Values; } }
    }
