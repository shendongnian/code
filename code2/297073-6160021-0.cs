    // 1 - using reflection
    // these will actually be your dynamically created objects...
    object a = CreateA();
    object b = CreateB();
    System.Reflection.MethodInfo set_someField1 = a.GetType().GetProperty("someField1").GetSetMethod();
    set_someField1.Invoke(a, new object[] { b });
