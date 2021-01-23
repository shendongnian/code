        // Get property array
        var properties = GetProperties(some_object);
        foreach (var p in properties)
            var value = p.GetValue(obj, null);
        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }
