    class DefaultGetter
    {
        T GetDefault<TClass, TProp>(string propertyName) where T : new()
        {        
            if (!defaults.TryGetValue(typeof(T), out var defaultValues)
                if (!defaultValues.TryGetValue(propertyName, out var value))
                {
                     // reflect on prototype getting all the PropertyInfo
                     // and store them in the dictionary of dictionaries
                     // then assign to value...
                     defaults[typeof(TClass)] = defaultValues = typeof(TClass).GetProperties().Select(x => new { x.Name, Value = x.GetConstantValue() }).ToDictionary(x => x.Name);
                }
                value = defaultValues[propertyName]
            }
            return (TProp)value;
        }
        IDictionary<Type, IDictionary<string, object> defaults = new ... // elided for brevity
    }
