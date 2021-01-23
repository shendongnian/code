    CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
    System.CodeDom.Compiler.CodeGeneratorOptions options = new CodeGeneratorOptions();
    options.BracingStyle = "C";
    using (StreamWriter sw = File.CreateText(@"c:\temp\MyFile.cs"))
    {
        provider.GenerateCodeFromCompileUnit(unit, sw, options);
    }
