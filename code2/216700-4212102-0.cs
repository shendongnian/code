    var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(
                 new AssemblyName("assembly"), AssemblyBuilderAccess.Run);
    var mod = ab.DefineDynamicModule("module");
    var tb = mod.DefineType("type", TypeAttributes.Public);
    var mb = tb.DefineMethod(
                 "test3", MethodAttributes.Public | MethodAttributes.Static);
    expression.CompileToMethod(mb);
    var t = tb.CreateType();
    var test3 = (Func<int, Foo>)Delegate.CreateDelegate(
                    typeof(Func<int, Foo>), t.GetMethod("test3"));
    int counter3 = 0;
    Stopwatch s3 = new Stopwatch();
    s3.Start();
    for (int i = 0; i < 300000000; i++)
    {
        counter3 += test3(i).Value;
    }
    s3.Stop();
    var result3 = s3.Elapsed;
