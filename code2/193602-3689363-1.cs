    Short answer: `myList.GetType().GetGenericArguments()[0]`
    Long answer:
        var objectType = myList.GetType();
        if (!objectType.IsGenericType() ||
            objectType.GetGenericTypeDefinition() != typeof(List<>))
        {
            throw new InvalidOperationException(
                "Object is not of type List<T> for any T");
        }
        var elementType = objectType.GetGenericArguments()[0];
