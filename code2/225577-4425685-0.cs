    Type listImplementation = destObject.GetType().GetInterface(typeof(IList<>).Name);
    if (listImplementation != null) {
        Type itemType = listImplementation.GetGenericArguments()[0];
        ...
    }
