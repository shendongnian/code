            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
            string output = "Out.exe";
            var parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = output;
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Drawing.Dll");
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.Dll");
            parameters.CompilerOptions = "/t:winexe";
            var results = codeProvider.CompileAssemblyFromSource(parameters, "namespace Bah { static class Program { static void Main() { System.Threading.Thread.Sleep(100000); } } }");
            
