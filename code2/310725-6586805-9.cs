    namespace Xxx.Services.Utils
        {
            public static class RulesAssemblyGenerator
            {
                static List<string> EntityTypesLoaded = new List<string>();
                public static void Execute(string typeName, string scriptCode)
                {
                    if (EntityTypesLoaded.Contains(typeName)) { return; } 
                    // only allow the assembly to load once per entityType per execution session
                    Compile(new CSharpCodeProvider(), scriptCode);
                    EntityTypesLoaded.Add(typeName);
                }
                private static void Compile(CodeDom.CodeDomProvider provider, string source)
                {
                    var param = new CodeDom.CompilerParameters()
                    {
                        GenerateExecutable = false,
                        IncludeDebugInformation = false,
                        GenerateInMemory = true
                    };
                    var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    var root_Dir = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Bin");
                    param.ReferencedAssemblies.Add(path);
                    // Note: This dependencies list are included as assembly reference and they should list out all dependencies
                    // That you may reference in your Rules or that your entity depends on.
                    // some assembly names were changed... clearly.
                    var dependencies = new string[] { "yyyyyy.dll", "xxxxxx.dll", "NHibernate.dll", "ABC.Helper.Rules.dll" };
                    foreach (var dependency in dependencies)
                    {
                        var assemblypath = System.IO.Path.Combine(root_Dir, dependency);
                        param.ReferencedAssemblies.Add(assemblypath);
                    }
                    // reference .NET basics for C# 2.0 and C#3.0
                    param.ReferencedAssemblies.Add(@"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.dll");
                    param.ReferencedAssemblies.Add(@"C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5\System.Core.dll");
                    var compileResults = provider.CompileAssemblyFromSource(param, source);
                    var output = compileResults.Output;
                    if (compileResults.Errors.Count != 0)
                    {
                        CodeDom.CompilerErrorCollection es = compileResults.Errors;
                        var edList = new List<DataRuleLoadExceptionDetails>();
                        foreach (CodeDom.CompilerError s in es)
                            edList.Add(new DataRuleLoadExceptionDetails() { Message = s.ErrorText, LineNumber = s.Line });
                        var rde = new RuleDefinitionException(source, edList.ToArray());
                        throw rde;
                    }
                }
            }
        }
