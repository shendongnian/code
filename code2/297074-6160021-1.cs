    // 1 - using reflection
    // these will actually be your dynamically created objects...
    object a = CreateA();
    object b = CreateB();
    System.Reflection.FieldInfo someField1 = a.GetType().GetField(
        "someField1", 
        BindingFlags.Instance | BindingFlags.NonPublic);
    someField1.SetValue(a, b);
