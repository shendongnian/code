Assembly assembly = Assembly.GetExecutingAssembly();
else:
Assembly assembly = Assembly.LoadFile("AssemblyPath");
Class Instance:
object obj = assembly.CreateInstance("ClassFullName"); //contains namespace
Or Try:
Type type = Type.GetType("ClassFullName"); //contains namespace
object obj = Activator.CreateInstance(type);
