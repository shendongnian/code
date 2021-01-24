    void Main()
    {
        var car = new Car();
        var imagens = PropertyGetter<Car, IFormFile>.GetValues(car);
    }
    
    public static class PropertyGetter<TObject, TPropertyType>
    {
        private static readonly PropertyInfo[] _properties;
        
        static PropertyGetter()
        {
            _properties = typeof(Car).GetProperties()
                .Where(x => x.PropertyType == typeof(TPropertyType))
                .ToArray();
        }
        
        public static TPropertyType[] GetValues(TObject obj)
        {
            var values = _properties
                .Select(x => (TPropertyType) x.GetValue(obj))
                .ToArray();
                
            return values;
        }
    }
