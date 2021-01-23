    Type userType = GetUserSuppliedType();
    // Now let's say userType is T.
    // Then here we are getting the type typeof(List<T>).
    // But, of course, there's no way to have any such information in the code.
    Type listOfUserType = typeof(List<>).MakeGenericType(new[] { userType });
    
    // This is effectively calling new List<T>();
    object listObject = Activator.CreateInstance(listOfUserType);
    
    // Do you see how messy this is getting?
    MethodInfo addMethod = listOfUserType.GetMethod("Add");
    // We better hope this matches userType!
    object input = GetUserSuppliedInput();
    // I suppose we could check it, to be sure...
    if (input == null || input.GetType() != userType)
    {
        throw new InvalidOperationException("That isn't going to work!");
    }
    // Here we are finally calling List<T>.Add(input) -- just in the most ass-
    // backwards way imaginable.
    addMethod.Invoke(listObject, new[] { input });
