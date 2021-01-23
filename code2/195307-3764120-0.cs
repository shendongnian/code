        string[] UnmatchedElements;
    CodeDomProvider CodeProvider = new Microsoft.CSharp.CSharpCodeProvider();
    CodeCompileUnit Code = StronglyTypedResourceBuilder.Create(filePath,
                       ClassName, NameSpace, CodeProvider, false, out UnmatchedElements);
    //System.Text.Encoding {System.Text.UTF8Encoding}
    StreamWriter writer = new StreamWriter(DesignerfilePath  ); // Needs to be Designer file path
    CodeProvider.GenerateCodeFromCompileUnit(Code, writer, new CodeGeneratorOptions());
    writer.Close();`
