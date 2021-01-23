    CodeDomProvider P = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("C#");
    CompilerParameters O = new CompilerParameters();
    O.GenerateInMemory = true;
    O.ReferencedAssemblies.Add(@"System.dll");
    //O.ReferencedAssemblies.Add(@"System.Net.dll");
    
    O.IncludeDebugInformation = false;
    
    CompilerResults R = P.CompileAssemblyFromSource(O, new string[] { "using System; using System.Reflection; namespace ABC.TestXXX {     // your source code goes here }" });
    
    Assembly _B_ = R.CompiledAssembly;
    // create an instance
    object YY = _B_.CreateInstance("ABC.TestXXX.MyClass");
    // call method returning bool and taking one string and one object
    YR = (bool)_B_.GetType("ABC.TestXXX.MyClass").GetMethod("TestB").Invoke(YY, new object[] { "Hallo", SomeObject });
