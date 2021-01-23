    using System.IO;
    using System.Reflection;
    
    string path = Path.GetDirectoryName(
                         Assembly.GetAssembly(typeof(MyClass)).CodeBase);
