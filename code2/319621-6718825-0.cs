    public static T Get<T>(Action beforeMethodCall, Action afterMethodCall)
    {
        Type interfaceType = typeof(T);
        // I assume MyContainer is wrapping an actual DI container, so
        // resolve the implementation type for T from it:
        T implementingObject = _myUnderlyingContainer.Resolve<T>();
        Type implementingType = implementingObject.GetType();
        // Get string representations of the passed-in Actions: this one is 
        // over to you :)
        string beforeMethodCode = GetExpressionText(beforeMethodCall);
        string afterMethodCode = GetExpressionText(afterMethodCall);
        // Loop over all the interface's methods and create source code which 
        // contains a method with the same signature which calls the 'before' 
        // method, calls the proxied object's method, then calls the 'after' 
        // method:
        string methodImplementations = string.Join(
            Environment.NewLine,
            interfaceType.GetMethods().Select(mi =>
            {
                const string methodTemplate = @"
    public {0} {1}({2})
    {{
        {3}
        this._wrappedObject.{1}({4});
        {5}
    }}";
                // Get the arguments for the method signature, like 
                // 'Type1' 'Name1', 'Type', 'Name2', etc.
                string methodSignatureArguments = string.Join(
                    ", ",
                    mi.GetParameters()
                        .Select(pi => pi.ParameterType.FullName + " " + pi.Name));
    
                // Get the arguments for the proxied method call, like 'Name1', 
                // 'Name2', etc.
                string methodCallArguments = string.Join(
                    ", ",
                    mi.GetParameters().Select(pi => pi.Name));
                // Get the method return type:
                string returnType = (mi.ReturnType == typeof(void)) ?
                    "void"
                    :
                    mi.ReturnType.FullName;
                // Create the method source code:
                return string.Format(
                    CultureInfo.InvariantCulture,
                    methodTemplate,
                    returnType,               // <- {0}
                    mi.Name,                  // <- {1}
                    methodSignatureArguments, // <- {2}
                    beforeMethodCode,         // <- {3}
                    methodCallArguments,      // <- {4}
                    afterMethodCode);         // <- {5}
            }));
        // Our proxy type name:
        string proxyTypeName = string.Concat(implementingType.Name, "Proxy");
        const string proxySourceTemplate = @"
    namespace Proxies
    {{
        public class {0} : {1}
        {{
            private readonly {1} _wrappedObject;
    
            public {0}({1} wrappedObject)
            {{
                this._wrappedObject = wrappedObject;
            }}
            {2}
        }}
    }}";
        // Get the proxy class source code:
        string proxySource = string.Format(
            CultureInfo.InvariantCulture,
            proxySourceTemplate,
            proxyTypeName,          // <- {0}
            interfaceType.FullName, // <- {1}
            methodImplementations); // <- {2}
        // Create the proxy in an in-memory assembly:
        CompilerParameters codeParameters = new CompilerParameters
        {
            MainClass = null,
            GenerateExecutable = false,
            GenerateInMemory = true,
            OutputAssembly = null
        };
        // Add the assembly that the interface lives in so the compiler can 
        // use it:
        codeParameters.ReferencedAssemblies.Add(interfaceType.Assembly.Location);
        // Compile the proxy source code:
        CompilerResults results = new CSharpCodeProvider()
            .CompileAssemblyFromSource(codeParameters, proxySource);
        // Create an instance of the proxy from the assembly we just created:
        T proxy = (T)Activator.CreateInstance(
            results.CompiledAssembly.GetTypes().First(),
            implementingObject);
        // Hand it back:
        return proxy;
    }
