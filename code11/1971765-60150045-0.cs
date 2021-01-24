var plugins = new List<IPlugin>();
var pluginsPath = Path.Combine(Application.StartupPath, "Plugins");
var referencesPath = Path.Combine(Application.StartupPath, "References");
var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll", SearchOption.AllDirectories);
var referenceFiles = Directory.GetFiles(referencesPath, "*.dll", SearchOption.AllDirectories);
AppDomain.CurrentDomain.AssemblyResolve += (obj, arg) =>
{
    var name = $"{new AssemblyName(arg.Name).Name}.dll";
    var assemblyFile = referenceFiles.Where(x => x.EndsWith(name))
        .FirstOrDefault();
    if (assemblyFile != null)
        return Assembly.LoadFrom(assemblyFile);
    throw new Exception($"'{name}' Not found");
};
foreach (var pluginFile in pluginFiles)
{
    var pluginAssembly = Assembly.LoadFrom(pluginFile);
    var pluginTypes = pluginAssembly.GetTypes().Where(x => typeof(IPlugin).IsAssignableFrom(x));
    foreach (var pluginType in pluginTypes)
    {
        var plugin = (IPlugin)Activator.CreateInstance(pluginType);
        MessageBox.Show(plugin.SayHello());
    }
}
# Detailed Example
In the following example, I assume you have the following solution structure:
* PluginCore: Contains `IPlugin.cs` - No dependency
* DependencyAssembly1: Contains `Class1.cs` - No dependency
* DependencyAssembly2: Contains `Class2.cs` - No dependency
* PluginAssembly1: Contains `Plugin1.cs` - Dependent to DependencyAssembly1, PluginCore
* PluginAssembly2: Contains `Plugin2.cs` - Dependent to DependencyAssembly1, DependencyAssembly2: PluginCore
* PluginSample: Contais Program.cs - Dependent to PluginCore
**PluginCore**
ClassLibrary project. No dependency. Just Contains `IPlugin.cs`.
*IPlugin.cs*
using System;
namespace PluginCore
{
    public interface IPlugin
    {
        string SayHello();
    }
}
**DependencyAssembly1**
ClassLibrary project. No dependency. Just contains `Class1.cs`
*Class1.cs*
using System;
using System.Diagnostics;
namespace DependencyAssembly1
{
    public class Class1
    {
        public void DoSomething()
        {
            Debug.WriteLine($"{nameof(Class1)}.{nameof(DoSomething)} called.");
        }
    }
}
**DependencyAssembly2**
ClassLibrary project. No dependency. Just contains `Class2.cs`
*Class2.cs*
using System;
using System.Diagnostics;
namespace DependencyAssembly2
{
    public class Class2
    {
        public void DoSomething()
        {
            Debug.WriteLine($"{nameof(Class2)}.{nameof(DoSomething)} called.");
        }
    }
}
**PluginAssembly1**
ClassLibrary project. Dependent to PluginCore, DependencyAssembly1. Just contains `Plugin1.cs`
*Plugin1.cs*
using PluginCore;
using System;
namespace PluginAssembly1
{
    public class Plugin1 : IPlugin
    {
        public string SayHello()
        {
            var c1 = new DependencyAssembly1.Class1();
            c1.DoSomething();
            return $"Hello from {nameof(Plugin1)}";
        }
    }
}
**PluginAssembly2**
ClassLibrary project. Dependent to PluginCore, DependencyAssembly1, DependencyAssembly2. Just contains `Plugin2.cs`
*Plugin2.cs*
using PluginCore;
using System;
namespace PluginAssembly2
{
    public class Plugin2 : IPlugin
    {
        public string SayHello()
        {
            var c1 = new DependencyAssembly1.Class1();
            var c2 = new DependencyAssembly2.Class2();
            c1.DoSomething();
            c2.DoSomething();
            return $"Hello from {nameof(Plugin2)}";
        }
    }
}
**PluginSample**
A ConsoleApplication project. Dependent to `PluginCore`. Just contains `Program.cs`.
*Program.cs*
using PluginCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
namespace PluginSample
{
    static class Program
    {
        static void Main()
        {
            var plugins = new List<IPlugin>();
            var pluginsPath = Path.Combine(Application.StartupPath, "Plugins");
            var referencesPath = Path.Combine(Application.StartupPath, "References");
            var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll", SearchOption.AllDirectories);
            var referenceFiles = Directory.GetFiles(referencesPath, "*.dll", SearchOption.AllDirectories);
            AppDomain.CurrentDomain.AssemblyResolve += (obj, arg) =>
            {
                var name = $"{new AssemblyName(arg.Name).Name}.dll";
                var assemblyFile = referenceFiles.Where(x => x.EndsWith(name))
                    .FirstOrDefault();
                if (assemblyFile != null)
                    return Assembly.LoadFrom(assemblyFile);
                throw new Exception($"'{name}' Not found");
            };
            foreach (var pluginFile in pluginFiles)
            {
                var pluginAssembly = Assembly.LoadFrom(pluginFile);
                var pluginTypes = pluginAssembly.GetTypes().Where(x => typeof(IPlugin).IsAssignableFrom(x));
                foreach (var pluginType in pluginTypes)
                {
                    var plugin = (IPlugin)Activator.CreateInstance(pluginType);
                    MessageBox.Show(plugin.SayHello());
                }
            }
        }
    }
}
