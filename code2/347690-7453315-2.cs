    public static string GenerateCode(Type interfaceType, string generatedClassName, Type baseClass)
    {
        //Sanity check
        if (!interfaceType.IsInterface)
            throw new ArgumentException("Interface expected");
        //I can't think of a good way to handle closed generic types so I just won't support them
        if (interfaceType.IsGenericType && !interfaceType.IsGenericTypeDefinition)
            throw new ArgumentException("Closed generic type not expected.");
        //Build the class
        var newClass = new CodeTypeDeclaration(generatedClassName)
        {
            IsClass = true,
            TypeAttributes = TypeAttributes.Public,
            BaseTypes =
                                    {
                                        //Include the interface and provided class as base classes
                                        MakeTypeReference(interfaceType),
                                        MakeTypeReference(baseClass)
                                    }
        };
        //Add type arguments (if the interface is generic)
        if (interfaceType.IsGenericType)
            foreach (var genericArgumentType in interfaceType.GetGenericArguments())
                newClass.TypeParameters.Add(genericArgumentType.Name);
        //Loop through each method
        foreach (var mi in interfaceType.GetMethods())
        {
            //Create the method
            var method = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Name = mi.Name,
                ReturnType = MakeTypeReference(mi.ReturnType)
            };
            //Add any generic types
            if (mi.IsGenericMethod)
                foreach (var genericParameter in mi.GetGenericArguments())
                    method.TypeParameters.Add(genericParameter.Name);
            //Add the parameters
            foreach (var par in mi.GetParameters())
                method.Parameters.Add(new CodeParameterDeclarationExpression(MakeTypeReference(par.ParameterType),
                                                                                par.Name));
            //Call the same method on the base passing all the parameters
            var allParameters =
                mi.GetParameters().Select(p => new CodeArgumentReferenceExpression(p.Name)).ToArray();
            var callBase = new CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), mi.Name, allParameters);
            //If the method is void, we just call base
            if (mi.ReturnType == typeof(void))
                method.Statements.Add(callBase);
            else
                //Otherwise, we return the value from the call to base
                method.Statements.Add(new CodeMethodReturnStatement(callBase));
            //Add the method to our class
            newClass.Members.Add(method);
        }
        //TODO: Also add properties if needed?
            
        //Make a "CompileUnit" that has a namespace with some 'usings' and then
        //  our new class.
        var unit = new CodeCompileUnit
        {
            Namespaces =
            {
                new CodeNamespace(interfaceType.Namespace)
                {
                    Imports =
                    {
                        new CodeNamespaceImport("System"),
                        new CodeNamespaceImport("System.Linq.Expressions")
                    },
                    Types =
                    {
                        newClass
                    }
                }
            }
        };
        //Use the C# prvider to get a code generator and generate the code
        //Switch this to VBCodeProvider to generate VB Code
        var gen = new CSharpCodeProvider().CreateGenerator();
        using (var tw = new StringWriter())
        {
            gen.GenerateCodeFromCompileUnit(unit, tw, new CodeGeneratorOptions());
            return tw.ToString();
        }
    }
    /// <summary>
    /// Helper method for expanding out a type with all it's generic types.
    /// It seems like there should be an easier way to do this but this work.
    /// </summary>
    private static CodeTypeReference MakeTypeReference(Type interfaceType)
    {
        //If the Type isn't generic, just wrap is directly
        if (!interfaceType.IsGenericType)
            return new CodeTypeReference(interfaceType);
        //Otherwise wrap it but also pass the generic arguments (recursively calling this method
        //  on all the type arguments.
        return new CodeTypeReference(interfaceType.Name,
                                        interfaceType.GetGenericArguments().Select(MakeTypeReference).ToArray());
    }
