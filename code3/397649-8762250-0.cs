        static void Main(string[] args)
        {
            var value = "9 3/4";
            value = value.Split(' ')[0] + "d + " + value.Split(' ')[1] + "d";
            var exp = " public class DynamicComputer { public static double Eval() { return " + value + "; }}";
            CodeDomProvider cp = new Microsoft.CSharp.CSharpCodeProvider();
            ICodeCompiler icc = cp.CreateCompiler();
            CompilerParameters cps = new CompilerParameters();
            CompilerResults cres;
            
            cps.GenerateInMemory = true;
            cres = icc.CompileAssemblyFromSource(cps, exp);
          
            Assembly asm = cres.CompiledAssembly;
            Type t = asm.GetType("DynamicComputer");
        
            double d = (double)t.InvokeMember("Eval",
                BindingFlags.InvokeMethod,
                null,
                null,
                null);
            Console.WriteLine(d);
            Console.Read();
        }
