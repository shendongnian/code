    // Find the generic argument type of your old list (theList)
    Type genericType = theList.GetType().GetGenericArguments()[0];
    // Create a new List with the same generic type as the old one
    Type newListType = typeof(List<>).MakeGenericType(genericType);
    // Create a new instance of the list with the generic type
    var instance = Activator.CreateInstance(newListType);
