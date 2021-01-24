    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    
    namespace CompilerTest
    {
        public class BuildEmit
        {
            private string _CoreAssemblyFolder = @"C:\Program Files\dotnet\sdk\NuGetFallbackFolder\microsoft.netcore.app\2.1.0\ref\netcoreapp2.1";
            private string _FrameworkAssemblyFolder = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.2";
    
            public BuildEmit() { }
    
            public List<string> Files { get; set; } = new List<string>();
            public string OutputFileNameAndPath { get; set; }
            public string ReferencedAssembliesPath { get; set; }
            public CompilerType Compiler { get; set; }
    
    
            public void Build()
            {
                string assemblyFolder = string.Empty;
                string coreAssemblyFileName = string.Empty;
                switch (Compiler)
                {
                    case CompilerType.Framework:
                        assemblyFolder = _FrameworkAssemblyFolder;
                        coreAssemblyFileName = "mscorlib.dll";
                        break;
                    case CompilerType.Core:
                        assemblyFolder = _CoreAssemblyFolder;
                        coreAssemblyFileName = "System.Runtime.dll";
                        break;
                }
                PortableExecutableReference objectDef = MetadataReference.CreateFromFile(Path.Combine(assemblyFolder, coreAssemblyFileName));
    
                List<SyntaxTree> syntaxes = new List<SyntaxTree>();
                foreach (string codeFile in Files)
                {
                    var code = File.ReadAllText(codeFile);
                    var tree = CSharpSyntaxTree.ParseText(code);
                    syntaxes.Add(tree);
                }
    
                var references = new List<PortableExecutableReference>();
                references.Add(objectDef);
    
                var assemblies = FilterInvalidAssembies(GetAssembliesInFolder(assemblyFolder));
                if (!string.IsNullOrWhiteSpace(ReferencedAssembliesPath))
                {
                    assemblies.AddRange(GetAssembliesInFolder(ReferencedAssembliesPath));
                }
                foreach (string item in assemblies)
                {
                    var reference = MetadataReference.CreateFromFile(item);
                    references.Add(reference);
                }
                var compilation = CSharpCompilation.Create(Path.GetFileNameWithoutExtension(OutputFileNameAndPath), syntaxes, references);
                compilation = compilation.WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    
                var emitResult = compilation.Emit(OutputFileNameAndPath);
    
                if (!emitResult.Success)
                {
                    foreach (var diagnostic in emitResult.Diagnostics)
                    {
                        Console.WriteLine(diagnostic.ToString());
                    }
                    File.Delete(OutputFileNameAndPath);
                }
            }
    
            private void RemoveStringFromList(List<string> items, string contains)
            {
                var item = items.Where(q => q.Contains(contains)).Select(q => q).FirstOrDefault();
                if (item != null)
                {
                    items.Remove(item);
                }
            }
    
            private List<string> FilterInvalidAssembies(List<string> files)
            {
                RemoveStringFromList(files, "System.EnterpriseServices.Wrapper.dll");
                RemoveStringFromList(files, "System.EnterpriseServices.Thunk.dll");
                //RemoveStringFromList(files, "mscorlib.dll");
                return files;
            }
    
            private List<string> GetAssembliesInFolder(string assemblyPath)
            {
                var files = Directory.GetFiles(assemblyPath, "*.dll");
    
                return files.ToList();
            }
    
        }
    }
    
