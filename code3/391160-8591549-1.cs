    public static int MethodOperation(int x, int y, string @operator)
        {
            var sharpCom = new CSharpCodeProvider();
            var results = sharpCom.CompileAssemblyFromSource(new CompilerParameters { GenerateInMemory = true, GenerateExecutable = false }, ClassString1 + string.Format("x {0} y", @operator) + ClassString2);
            return (int)results.CompiledAssembly.GetTypes().First().GetMethods().First().Invoke(null, new object[] { x, y });
        }
