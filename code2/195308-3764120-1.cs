	string[] unmatchedElements;
	var codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
	System.CodeDom.CodeCompileUnit code =
		System.Resources.Tools.StronglyTypedResourceBuilder.Create(
			"MyClass.resx", "MyClass", "my.namespace", codeProvider, 
			true, out unmatchedElements); // Needs System.Design.dll
	using(StreamWriter writer = new StreamWriter("MyClass.Designer.cs", false,
		System.Text.Encoding.UTF8))
	{
		codeProvider.GenerateCodeFromCompileUnit(code, writer,
			new System.CodeDom.Compiler.CodeGeneratorOptions());
	}
	// Returns false if at least one ppty couldn't be generated.
	return unmatchedElements.Length == 0; 
