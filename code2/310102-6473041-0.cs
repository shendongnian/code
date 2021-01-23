    string path = Directory.GetCurrentDirectory();
    string target = Path.Combine(path, @"./myclass.dll");
    Assembly asm = Assembly.LoadFrom(target);
    Type type = asm.GetType("MyClass.Calculator");
    ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
    ctor.Invoke (null);
    MethodInfo m = type.GetMethod("Add");
    int res = (int) m.Invoke(h, param);
    Console.WriteLine("{0}", res);      
