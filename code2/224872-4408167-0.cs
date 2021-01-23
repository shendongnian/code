    public class MyClass
    {
        public string MyProperty1 { get; set; }
        public object this[string propName]
        {
            get
            {
                return GetType().GetProperty(propName).GetValue(this, null);
            }
            set
            {
                GetType().GetProperty(propName).SetValue(this, value, null);
            }
        }
    }
