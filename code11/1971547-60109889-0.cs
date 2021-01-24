    public class ExampleClass{
    
        public object this[string name]
        {
            get
            {
                var properties = typeof(ExampleClass)
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
                foreach (var property in properties)
                {
                    if (property.Name == name && property.CanRead)
                        return property.GetValue(this, null);
                }
    
                throw new ArgumentException("Can't find property");
    
            }
            set {
                return;
            }
        }
    }
