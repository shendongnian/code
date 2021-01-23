    var foo = new DerivedClass2();
    var result = typeof(DerivedClass2).GetField("subItem", 
                                                BindingFlags.NonPublic | 
                                                BindingFlags.Instance)
                                      .GetValue(foo);
    Type myType = result.GetType().GetGenericArguments()[0];
