    private static MethodInfo GetMethodImplementation(Type implementationType, MethodInfo ifaceMethod)
    {
      InterfaceMapping ifaceMap = implementationType.GetInterfaceMap(ifaceMethod.DeclaringType);
      for (int i = 0; i < ifaceMap.InterfaceMethods.Length; i++)
      {
        if (ifaceMap.InterfaceMethods[i].Equals(ifaceMethod))
          return ifaceMap.TargetMethods[i];
      }
      throw new Exception("Method missing from interface mapping??"); // We shouldn't get here
    }
    ...
      Foo obj = new Foo();
      MethodInfo ifaceMethod = typeof(IFoo).GetMethod("GetAnswer");
      MethodInfo implementationMethod = GetMethodImplementation(typeof(Foo), ifaceMethod);
      Console.WriteLine("GetAnswer(): {0}, has AnswerAttribute: {1}",
        implementationMethod.Invoke(obj, null),
        implementationMethod.GetCustomAttribute<AnswerAttribute>() != null);
