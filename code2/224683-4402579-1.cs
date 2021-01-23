    var myBarClass = testAssembly.GetType("MyNamespace.foo")
                                 .GetField("myBarClass", BindingFlags.NonPublic |
                                                         BindingFlags.Static)
                                 .GetValue(null);
    mi.Invoke(myBarClass, null);
