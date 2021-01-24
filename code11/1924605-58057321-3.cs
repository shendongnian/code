				// in project C#
        private Func<double, double, double> betterFunction;
        private MethodInfo CreateAndCompileFunction(string filename)
        {
            FileInfo fi = new FileInfo(@".\folder\CurveAssembly.dll");
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters compilerparams = new CompilerParameters();
            compilerparams.OutputAssembly = @".\folder\CurveAssembly.dll";
            CompilerResults results = provider.CompileAssemblyFromFile(compilerparams, filename);
            if (results.Errors.Count > 0)
            {
                // Display compilation errors.
                Console.WriteLine("Errors building {0} into {1}",
                    fi.FullName, results.PathToAssembly);
                foreach (CompilerError ce in results.Errors)
                {
                    Console.WriteLine("  {0}", ce.ToString());
                }
            }
            else
            {
                // Display a successful compilation message.
                Console.WriteLine("Source {0} built into {1} successfully.",
                    fi.FullName, results.PathToAssembly);
            }
            Type binaryFunction = results.CompiledAssembly.GetType("UserFunction.BinaryFunction");
            return binaryFunction.GetMethod("MyFunction");
        }
        public void compileFunction(string curvename)
        {
            MethodInfo function = CreateAndCompileFunction(@".\folder\curve.txt");
            betterFunction = (Func<double, double, double>)Delegate.CreateDelegate(typeof(Func<double, double, double>), function);
        }
        //calling the method inside the dll (betterfunction)
        public double MyFunction(double x, double param)
        {
            return betterFunction(x, param);
        }
