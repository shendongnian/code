    static class Delegates
    {
        private static Func<Func<int, string>> _test;
        public static Func<int, string> Test
        {
            get
            {
                return _test();
            }
        }
        static Delegates()
        {
            // Use your config variables instead of the "return arg.ToString();"
            CreateFactory<Func<int, string>>(x => _test = x, "return arg.ToString();");
        }
        private static void CreateFactory<TDelegate>(Action<Func<TDelegate>> locationSetter, string identifier)
        {
            locationSetter(() =>
                {
                    var result = Generate<TDelegate>(identifier);
                    locationSetter(() => result);
                    return result;
                });
        }
        private static string GenerateSignature<TDelegate>()
        {
            // Create the signature of the delegate.
            var t = typeof(TDelegate);
            if (!typeof(Delegate).IsAssignableFrom(t))
                throw new Exception("TDelegate must be delegate type.");
            var invoke = t.GetMethod("Invoke");
            var sig = new StringBuilder();
            // Append the return type.
            if (invoke.ReturnType == typeof(void))
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
            return sig.ToString();
        }
        private static TDelegate Generate<TDelegate>(string code)
        {
            // Generate the containing class and method.
            var codeBuilder = new StringBuilder(50);
            codeBuilder.AppendLine("using System;");
            codeBuilder.Append("namespace Dynamic { class DynamicClass { public static ");
            codeBuilder.Append(GenerateSignature<TDelegate>());
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
                new Dictionary<string, string>() { { "CompilerVersion", string.Format("v{0}.{1}", compilerVersion.Major, compilerVersion.Minor) } }
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
            return (TDelegate)(object)Delegate.CreateDelegate(typeof(TDelegate), m);
        }
    }
