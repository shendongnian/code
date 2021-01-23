    MyGeneric<MyClass1> myList = new MyGeneric<MyClass1>();
    if(myList.GetType() == typeof(MyGeneric<>))
    {
        // Not equal
    }
    // WARNING: DO NOT USE THIS CODE AS-IS!
    //   - There are no error checks at all
    //   - It should be checking that myList.GetType() is a constructed generic type
    //   - It should be checking that the generic type definitions are the same
    //     (does not because in this specific example they will be)
    //   - The IsAssignableFrom check might not fit your requirements 100%
    var args = myList.GetType().GetGenericArguments();
    if (typeof(MyBaseClass).IsAssignableFrom(args.Single()))
    {
        // This test should succeed
    }
