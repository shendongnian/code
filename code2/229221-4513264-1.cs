    Type genericListType = typeof(List<>);
    Type userType = GetUserSuppliedType();
    // Now let's say userType happens to be typeof(int).
    // Then here we are getting the type typeof(List<int>).
    // But, of course, there's no way to have any such information
    // in the code itself.
    Type listOfUserType = genericListType.MakeGenericType(new[] { userType });
    
    object listObject = Activator.CreateInstance(listOfUserType);
    
    // Do you see how messy this is getting?
    MethodInfo addMethod = listOfUserType.GetMethod("Add");
    // We better hope this matches userType!
    object input = GetUserSuppliedInput();
    if (input.GetType() != userType)
    {
        throw new InvalidOperationException("That isn't going to work!");
    }
    // At last here we are effectively calling List<int>.Add(),
    // but in the most ass-backwards way imaginable.
    addMethod.Invoke(listObject, new[] { input });
