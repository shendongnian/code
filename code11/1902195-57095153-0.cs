lang-cs
using System;
using System.IO;
using System.Linq;
using System.Reflection;
publi class Class1
{
    static Class1()
    {
        var dllDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
            if (assembly != null)
            {
                return assembly;
            }
            var fileName = args.Name.Split(',')[0] + ".dll";
            var filePath = Path.Combine(dllDirectory, fileName);
            if (File.Exists(filePath))
            {
                return Assembly.LoadFile(filePath);
            }
            return null;
        };
    }
    // ...
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.appdomain.assemblyresolve?view=netframework-4.8
