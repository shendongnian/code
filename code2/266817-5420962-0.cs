    public static String TestMethod1(int a, ref int X, out string t)
    {
    	a += X;
    	X = a * 2;
    	t = "...>" + (X + a);
    	return a.ToString() + "...";
    }
    
    public class TestClass
    {
    	public int SomeMethod(int a, DateTime? xyz)
    	{
    	  if(xyz != null)
    			a+= xyz.GetValueOrDefault().Day;
    		return 12 + a;
    	}
    }
    
    void Main()
    {
    	var sb = new StringBuilder();
    
    	var methodInfo = typeof(UserQuery).GetMethod("TestMethod1");
    	
    	dynamic instance = CreateWrapper(methodInfo, sb);
    	
    	instance.a = 11;
    	instance.X = 2;
    	
    	instance.CallMethod();
    
    	/*
    	var methodInfo = typeof(TestClass).GetMethod("SomeMethod");
    	
    	dynamic instance = CreateWrapper(methodInfo, sb);
    	
    	instance.a = 11;
    	instance.xyz = new DateTime(2010, 1, 2);
    
    	instance.CallMethod(new TestClass());
    */
    	((Object)instance).Dump();
    
    	sb.ToString().Dump();
    }
    
    static object CreateWrapper(MethodInfo methodInfo, StringBuilder sb)
    {
      // pick either C#, VB or another language that can handle generics
    	var codeDom = CodeDomProvider.CreateProvider("C#");
    	
    	var unit = new CodeCompileUnit();
    	var codeNameSpace = new CodeNamespace();
    	codeNameSpace.Name = "YourNamespace";
    	var wrapperType = AddWrapperType(codeDom, codeNameSpace, methodInfo, "WrapperType", 	"MethodResultValue");
    	
    	unit.Namespaces.Add(codeNameSpace);
    	
    	// this is only needed so that LinqPad can dump the code
    	codeDom.GenerateCodeFromNamespace(codeNameSpace, new StringWriter(sb), new CodeGeneratorOptions());
    
    	// put the temp assembly in LinqPad's temp folder
    	var outputFileName = Path.Combine(Path.GetDirectoryName(new Uri(typeof(UserQuery).Assembly.CodeBase).AbsolutePath), 
    																	  Guid.NewGuid() + ".dll");
    	var results = codeDom.CompileAssemblyFromDom(new CompilerParameters(new[]{new Uri(methodInfo.DeclaringType.Assembly.CodeBase).AbsolutePath,
    	                                                                          new Uri(typeof(UserQuery).Assembly.CodeBase).AbsolutePath,
    	                                                                          new Uri(typeof(UserQuery).BaseType.Assembly.CodeBase).AbsolutePath}.Distinct().ToArray(),
    																																						outputFileName), 
    																							 unit);
    	results.Errors.Dump();
    	new Uri(results.CompiledAssembly.CodeBase).AbsolutePath.Dump();
    	
    	if(results.Errors.Count == 0)
    	{
    		var compiledType = results.CompiledAssembly.GetType(codeNameSpace.Name + "." + wrapperType.Name);
    		
    		return Activator.CreateInstance(compiledType);
    	}
    	return null;
    }
    
    
    static CodeTypeDeclaration AddWrapperType(CodeDomProvider codeDom, 
                                              CodeNamespace codeNameSpace, 
    																					MethodInfo methodInfo, 
    																					string typeName, 
    																					string resultPropertyName)
    {
    	var parameters = (from parameter in methodInfo.GetParameters()
    	                  select parameter).ToList();
    	
    	var returnValue = methodInfo.ReturnType;
    	
    	if(!String.IsNullOrEmpty(methodInfo.DeclaringType.Namespace))
    		codeNameSpace.Imports.Add(new CodeNamespaceImport(methodInfo.DeclaringType.Namespace));
    	
    	var wrapperType = new CodeTypeDeclaration(typeName);
    
    	var defaultAttributes = MemberAttributes.Public | MemberAttributes.Final;
    	var thisRef = new CodeThisReferenceExpression();
    		
    	Func<Type, Type> getRealType = t => t.IsByRef || t.IsPointer ? t.GetElementType(): t;
    	
    	
    	Func<String, String> getFieldName = parameterName => "m_" + parameterName + "_Field";
    	
    	
    	Action<ParameterInfo> addProperty = p =>
    	{
    		var realType = getRealType(p.ParameterType);
    		var usedName = p.Position == -1 ? resultPropertyName : p.Name;
    		
    		wrapperType.Members.Add(new CodeMemberField
    		{
    			Name = getFieldName(usedName),
    			Type = new CodeTypeReference(realType),
    			Attributes= MemberAttributes.Private
    		});
    		
    		var property = new CodeMemberProperty
    										{
    											Name = usedName,
    									 		Type = new CodeTypeReference(realType),
    										  Attributes= defaultAttributes
    										};
    										
    		property.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(thisRef,  
    		                                                                                          getFieldName(usedName))));
    		property.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(thisRef,  getFieldName(usedName)), 
    		                                                   new CodeArgumentReferenceExpression("value")));
    										
    		wrapperType.Members.Add(property);
    	};
    	
    	parameters.ForEach(addProperty);
    	if(methodInfo.ReturnParameter != null)
    	{
    		addProperty(methodInfo.ReturnParameter);
    	}
    	
    	var callMethod = new CodeMemberMethod
    	{
    		Name="CallMethod", 
    		Attributes=defaultAttributes
    	};
    	
    	CodeMethodInvokeExpression invokeExpr;
    	
    	if(!methodInfo.IsStatic)
    	{
    		callMethod.Parameters.Add(new CodeParameterDeclarationExpression(methodInfo.DeclaringType, 
    		                                                                 "instance"));
    		invokeExpr = new CodeMethodInvokeExpression(new CodeArgumentReferenceExpression("instance"),
    		                                            methodInfo.Name);
    	}
    	else
    		invokeExpr = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(methodInfo.DeclaringType), methodInfo.Name);
    	
    	foreach(var parameter in parameters)
    	{
    		CodeExpression fieldExpression = new CodeFieldReferenceExpression(thisRef, 
    		                                                                  getFieldName(parameter.Name));
    		
    		if(parameter.ParameterType.IsByRef && !parameter.IsOut)
    			fieldExpression = new CodeDirectionExpression(FieldDirection.Ref, fieldExpression);
    		else if(parameter.IsOut)
    			fieldExpression = new CodeDirectionExpression(FieldDirection.Out, fieldExpression);
    		else if(parameter.IsIn)
    		   fieldExpression = new CodeDirectionExpression(FieldDirection.In, fieldExpression);
    			 
    		invokeExpr.Parameters.Add(fieldExpression);
    	}
    	
    	wrapperType.Members.Add(callMethod);
    	
    	if(returnValue != typeof(void))
    		callMethod.Statements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(thisRef,
    		                                                                                   getFieldName(resultPropertyName)),
    																									    invokeExpr));
    	else
    		callMethod.Statements.Add(invokeExpr);
    	
    	codeNameSpace.Types.Add(wrapperType);
    	
    	return wrapperType;
    }
