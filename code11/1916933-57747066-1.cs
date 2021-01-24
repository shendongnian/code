csharp
using System.Text.RegularExpressions;
using alias = System.Int32;
namespace ConsoleApp3
{
    public class DummyClass1
    {
        public alias DummyProperty { get; set; }
    }
}
F2.cs
csharp
using System;
namespace ConsoleApp3
{
    public class DummyClass2
    {
        public Int32 Kek { get; set; }
    }
}
Here's a quick and dirty program I wrote that merges two C# files together using a parser (warning: not production quality code):
csharp
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
namespace ConsoleApp3
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var sourceFiles = await Task.WhenAll( // reading input files
                File.ReadAllTextAsync("F1.cs"),
                File.ReadAllTextAsync("F2.cs"));
            var syntaxTrees = sourceFiles.Select(x => CSharpSyntaxTree.ParseText(x)).ToArray(); // parsing syntax trees
            var roots = syntaxTrees.Select(x => x.GetRoot()).ToArray(); // getting syntax tree roots
            var usingStatements = roots // retrieving using statements from both files
                .SelectMany(root => root.ChildNodes().Where(node => node.Kind() == SyntaxKind.UsingDirective))
                .ToArray();
            var namespaceDeclarations = roots // retrieving namespace declaration statements from both files
                .SelectMany(root => root.ChildNodes().Where(node => node.Kind() == SyntaxKind.NamespaceDeclaration))
                .ToArray();
            var combined = string.Join(Environment.NewLine, // combining usings and namespace declarations
                string.Join(Environment.NewLine, usingStatements.Select(x => x.ToString())),
                string.Join(Environment.NewLine, namespaceDeclarations.Select(x => x.ToString())));
            Console.WriteLine(combined);
        }
    }
}
Here's how the output looks for my F1.cs and F2.cs files:
csharp
using System.Text.RegularExpressions;
using alias = System.Int32;
using System;
namespace ConsoleApp3
{
    public class DummyClass1
    {
        public alias DummyProperty { get; set; }
    }
}
namespace ConsoleApp3
{
    public class DummyClass2
    {
        public Int32 Kek { get; set; }
    }
}
Yeah... Two namespace declarations of the same namespace... Not pretty, but this is valid C#, so I didn't bother doing anything about it. This file compiles and works as you would expect.
Still, let me assure you - this approach is going to be much easier than wrestling with regular expressions' corner cases, and it only took me five to ten minutes to come up with this, and it's the first time I'm using a C# parser, so it's definitely not rocket science.
Oh, and you'll have to depend on Roslyn by installing `Microsoft.CodeAnalysis.CSharp` NuGet package. Though it's a small price to pay.
