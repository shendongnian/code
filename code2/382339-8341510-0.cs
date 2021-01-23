    using System.Linq;
    
    ....
    var concreteGenericTypes =
        (from assembly in AppDomain.CurrentDomain.GetAssemblies()
         from T in assembly.GetTypes()
         where T.IsClass && T.GetConstructor(new Type[] { }) != null
         select typeof(MyClass<>).MakeGenericType(T)).ToList();
