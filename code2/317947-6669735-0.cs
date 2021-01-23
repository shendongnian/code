    var compiler = new CSharpCodeProvider();
    var invocation = new CodeMethodInvokeExpression(
        new CodeTypeReferenceExpression(typeof(Public)),
        "ReadAllData", new CodePrimitiveExpression(@"C:\File.exe"));
    var stringWriter = new StringWriter();
    compiler.GenerateCodeFromExpression(invocation, stringWriter, null);
    Console.WriteLine(stringWriter.ToString());
