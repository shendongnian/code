    public class Parameter<T> : IParameter
    {
        public string Name{get;set;}
    	public T Value {get;set;}
    	public string ValueType {get => typeof(T).Name;}
    	
    	object IParameter.Value {get => this.Value;}
    }
