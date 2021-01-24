    public class MyClass
    {
        public MyClass(IService service, IEnumerable<int> values) 
          : this(service, values, valus.FirstOrDefault(i => i == service.GetDefaultValue()) {}
        public MyClass(IService service, IEnumerable<int> values, int value)
        {
            Service = service;
            Values = values;
            Value = value;
        }
    }
