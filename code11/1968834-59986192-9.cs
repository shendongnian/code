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
            _properties = typeof(TObject).GetProperties()
                // "IsAssignableFrom" is used to support derived types too
                .Where(x => typeof(TPropertyType).IsAssignableFrom(x.PropertyType))
                // Check that the property is accessible
                .Where(x => x.GetMethod != null && x.GetMethod.IsPublic && !x.GetMethod.IsStatic)
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
