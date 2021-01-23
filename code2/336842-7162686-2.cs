    class Program
    {
        static void Main(string[] args)
        {
            var del = DelegateFactory<Func<int, string>>.Generate("Test");
            Console.WriteLine(del(1));
            Console.ReadLine();
        }
    }
    class DelegateFactory<TDelegate>
    {
        private static readonly Dictionary<string, TDelegate> _factories 
            = new Dictionary<string, TDelegate>(StringComparer.OrdinalIgnoreCase);
        private static readonly string Signature;
        static DelegateFactory()
        {
            // Create the signature of the delegate.
            var t = typeof(TDelegate);
            if (!typeof(Delegate).IsAssignableFrom(t))
                throw new Exception("TDelegate must be delegate type.");
            var invoke = t.GetMethod("Invoke");
            var sig = new StringBuilder();
            // Append the return type.
            if(invoke.ReturnType == typeof(void))
                sig.Append("void");
            else
                sig.Append(invoke.ReturnType.FullName);
            sig.Append(" ");
            sig.Append("Invoke(");
            // Append the parameters.
            var param = invoke.GetParameters();
            for (var i = 0; i < param.Length; i++)
            {
                if (i != 0)
                    sig.Append(", ");
                sig.Append(param[i].ParameterType.FullName);
                sig.Append(" ");
                sig.Append(param[i].Name);
            }
            sig.Append(")");
            Signature = sig.ToString();
        }
        public static TDelegate Generate(string identifier)
        {
            TDelegate result;
            lock (_factories)
            {
                if (_factories.TryGetValue(identifier, out result))
                    return result;
                // Generate the containing class and method.
                var code = GetCode(identifier);
                var codeBuilder = new StringBuilder(50);
                codeBuilder.AppendLine("using System;");
                codeBuilder.Append("namespace Dynamic { class DynamicClass { public static ");
                codeBuilder.Append(Signature);
                codeBuilder.AppendLine("{");
                codeBuilder.AppendLine(code);
                codeBuilder.AppendLine("} } }");
                var compilerVersion = new Version(1, 0, 0, 0);
                // Create the compiler parameters.
                var parameters = new CompilerParameters();
                parameters.GenerateInMemory = true;
                parameters.GenerateExecutable = false;
                parameters.ReferencedAssemblies.Clear();
                foreach (var referenceAssembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    parameters.ReferencedAssemblies.Add(referenceAssembly.Location);
                    // Figure out which version we are compiling against.
                    var an = new AssemblyName(referenceAssembly.FullName);
                    if (an.Name == "mscorlib" && compilerVersion < an.Version)
                    {
                        compilerVersion = an.Version;
                    }
                }
                var cp = new CSharpCodeProvider(
                    new Dictionary<string, string>() 
                        { { "CompilerVersion", string.Format("v{0}.{1}", compilerVersion.Major, compilerVersion.Minor) } }
                    );
                var results = cp.CompileAssemblyFromSource(parameters, codeBuilder.ToString());
                if (results.Errors.HasErrors)
                    throw new Exception("Method failed to compile.");
                var assembly = results.CompiledAssembly;
                if (assembly == null)
                    throw new Exception("Method failed to compile.");
                var t = assembly.GetType("Dynamic.DynamicClass");
                if (t == null)
                    throw new Exception("Method failed to compile.");
                var m = t.GetMethod("Invoke");
                if (m == null)
                    throw new Exception("Method failed to compile.");
                result = (TDelegate)(object)Delegate.CreateDelegate(typeof(TDelegate), m);
                if (!_factories.ContainsKey(identifier))
                    _factories.Add(identifier, result);
            }
            return result;
        }
        private static string GetCode(string identifier)
        {
            // Your job.
            return string.Format("return arg.ToString() + \"{0}\";", identifier);
        }
    }
