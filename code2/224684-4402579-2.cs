    Assembly testAssembly= Assembly.LoadFrom(@"c:\test.dll");
    Type t = testAssembly.GetType("MyNamespace.bar");
    BindingFlags bf = BindingFlags.Instance | BindingFlags.NonPublic;
    MethodInfo mi = t.GetMethod("aMethod", bf);
    object myBarClass = testAssembly.GetType("MyNamespace.foo")
                                    .GetField("myBarClass", BindingFlags.NonPublic |
                                                            BindingFlags.Static)
                                    .GetValue(null);
    mi.Invoke(myBarClass, null);
