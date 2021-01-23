    private bool Compare(Type type, string[] propertyNames, object[] oldState, object[] state) {
        // Get the property indexes to ignore
        var propertyIndexesToIgnore = type.GetProperties()
            .Where(p => p.GetCustomAttributes(typeof(IgnoreLoggingAttribute), false).Count() > 0)
            .Select(p => Array.IndexOf(propertyNames, p.Name)).ToArray();
    
        // Get the child property indexes
        var childPropertyIndexes = type.GetProperties()
            .Where(p => p.GetCustomAttributes(typeof(ChildLoggingAttribute), false).Count() > 0)
            .Select(p => Array.IndexOf(propertyNames, p.Name)).ToArray();
    
        for (var i = 0; i < oldState.Length; i++) {
            // If we need to check the child properties
            if (childPropertyIndexes.Contains(i)) {
                if (oldState[i] == null)
                    break;
    
                var childPropertyType = oldState[i].GetType();
                var childProperties = oldState[i].GetType().GetProperties();
    
                // Recursively call this function to check the child properties
                if (Compare(childPropertyType, childProperties.Select(p => p.Name).ToArray(), childProperties.Select(p => p.GetValue(oldState[i], null)).ToArray<object>(), childProperties.Select(p => p.GetValue(state[i], null)).ToArray<object>()))
                    return true;
            } else if (!propertyIndexesToIgnore.Contains(i) && ((oldState[i] != null && state[i] != null && !oldState[i].Equals(state[i])) || (oldState[i] != null && state[i] == null) || (oldState[i] == null && state[i] != null)))
                return true;
        }
    
        return false;
    }
