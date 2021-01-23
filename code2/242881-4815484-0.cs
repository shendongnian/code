using System;
using System.CodeDom;
using System.Runtime.InteropServices;
using System.Workflow.ComponentModel.Compiler;
namespace Samples
{
    class Program
    {
        static CodeCompileUnit BuildHelloWorldGraph()
        {
            var compileUnit = new CodeCompileUnit();
            var samples = new CodeNamespace("Samples");
            compileUnit.Namespaces.Add(samples);
            var class1 = new CodeTypeDeclaration("Class1");
            samples.Types.Add(class1);
            return compileUnit;
        }
        static void Main(string[] args)
        {
            var unit = BuildHelloWorldGraph();
            var typeProvider = new TypeProvider(null);
            typeProvider.AddCodeCompileUnit(unit);
            var t = typeProvider.GetType("Samples.Class1");
            Console.WriteLine(t.GUID); // prints GUID for design time type instance.
            Console.WriteLine(Marshal.GenerateGuidForType(t)); // throws ArgumentException.
        }
    }
}
