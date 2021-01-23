    Assembly assembly = Assembly.Load(); //assembly of "Test"
    Type testType = assembly.GetType("Test");
    ConstructorInfo ci = testType.GetConstructor(
                                  BindingFlags.Public | BindingFlags.Instance, 
                                  null, 
                                  new Type[]{typeof(string), typeof(string)}, 
                                  null);
    Test objTest = ci.Invoke(new object[] { "name", "type" });
