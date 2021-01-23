        var listType = customerList.GetType();
        if (!listType.IsGeneric || listType.GetGenericTypeDefinition() != typeof(List<>))
            // It’s not a List<T>
            return null;
        return !listType.GetGenericArguments()[0].IsValueType;
