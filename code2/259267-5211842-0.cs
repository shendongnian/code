    var foo = new DerivedClass2();
    var result = typeof(DerivedClass2).GetField("subItem", 
                                                BindingFlags.NonPublic | 
                                                BindingFlags.Instance)
                                      .GetValue(foo);
    var genericClassField = result as GenericClass<DerivedClass1>;
