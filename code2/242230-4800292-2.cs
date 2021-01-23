    //Create method
    CodeMemberMethod pMethod = new CodeMemberMethod();
    pMethod.Name = methodname;
    pMethod.Attributes = MemberAttributes.Public;
    pMethod.Parameters.Add(new
    CodeParameterDeclarationExpression(typeof(string[]),"boxes"));
    pMethod.ReturnType=new CodeTypeReference(typeof(bool));
    pMethod.Statements.Add(new CodeSnippetExpression(@"
    bool result=true;
    try
    {
        "+source+@"
    }
    catch
    {
        result = false;
    }
    return result;
    "));
    //Crée la classe
    CodeTypeDeclaration pClass = 
      new System.CodeDom.CodeTypeDeclaration(classname);
    pClass.Attributes = MemberAttributes.Public;
    pClass.Members.Add(pMethod);
    //Crée le namespace
    CodeNamespace pNamespace = new CodeNamespace("myNameSpace");
    pNamespace.Types.Add(pClass);
    foreach(string sUsing in usingList)
      pNamespace.Imports.Add(new
        CodeNamespaceImport(sUsing));
    //Create compile unit
    CodeCompileUnit pUnit = new CodeCompileUnit();
    pUnit.Namespaces.Add(pNamespace);
    //Make compilation parameters
    CompilerParameters pParams = 
      new CompilerParameters((string[])importList.ToArray(typeof(string)));
    pParams.GenerateInMemory = true;
    //Compile
    CompilerResults pResults =
      (new CSharpCodeProvider())
        .CreateCompiler().CompileAssemblyFromDom(pParams, pUnit);
    if (pResults.Errors != null && pResults.Errors.Count&gt;0)
    {
        foreach(CompilerError pError in pResults.Errors)
          MessageBox.Show(pError.ToString());
        result =
        pResults.CompiledAssembly.CreateInstance("myNameSp ace."+classname);
    }
